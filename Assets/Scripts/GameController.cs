using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
  public enum Status
  {
    waiting,
    playing
  }

  public GameObject PF_WinParticles;
  public BallController ball;
  public PlayerController playerLeft;
  public PlayerController playerRight;
  public GameObject scoreText;
  public GameObject startText;
  public GameObject winnerText;

  public float winParticlesXPosLeft;
  public float winParticlesXPosRight;
  public int winningScore;

  private int scoreLeft;
  private int scoreRight;
  private Status status;
  private Direction lastPoint;

  private void Start()
  {
    status = Status.waiting;
  }

  public void StartRound()
  {
    if (status != Status.waiting)
    {
      return;
    }

    if (scoreLeft == 0 && scoreRight == 0)
    {
      ball.FirstPush();
    }
    else
    {
      ball.Push(lastPoint == Direction.left ? Direction.right : Direction.left);
    }

    status = Status.playing;
    startText.SetActive(false);
    scoreText.GetComponent<Animation>().Play();
  }

  public void Score(Direction dir, Vector2 pos)
  {
    ball.Reset();
    playerLeft.Reset();
    playerRight.Reset();

    SpawnScoreParticles(dir, pos);

    lastPoint = dir;
    status = Status.waiting;

    startText.SetActive(true);
    scoreText.GetComponent<TextMeshProUGUI>().alpha = 1f;
    scoreText.GetComponent<Animation>().Stop();

    if (scoreLeft >= winningScore || scoreRight >= winningScore)
    {
      TextMeshProUGUI TMP = winnerText.GetComponent<TextMeshProUGUI>();

      if (scoreLeft >= winningScore)
      {
        TMP.text = "Left Wins !";
      }
      else if (scoreRight >= winningScore)
      {
        TMP.text = "Right Wins !";
      }

      TMP.alpha = 1.0f;
      winnerText.GetComponent<Animation>().Play();
      scoreLeft = 0;
      scoreRight = 0;
    }
  }

  private void SpawnScoreParticles(Direction dir, Vector2 pos)
  {
    Vector2 spawnPoint = new Vector2(0f, pos.y);
    Vector3 rot = new Vector3(0f, 90f, 90f);

    if (dir == Direction.left)
    {
      scoreRight++;
      spawnPoint.x = winParticlesXPosLeft;
      rot.x = 0f;
    }
    else
    {
      scoreLeft++;
      spawnPoint.x = winParticlesXPosRight;
      rot.x = 180f;
    }

    Instantiate(PF_WinParticles, spawnPoint, Quaternion.Euler(rot));
  }

  private void Update()
  {
    scoreText.GetComponent<TextMeshProUGUI>().text = scoreLeft + " - " + scoreRight;
  }
}
