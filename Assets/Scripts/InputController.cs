using UnityEngine;

public class InputController : MonoBehaviour
{
  public PlayerController playerLeft;
  public PlayerController playerRight;
  public GameController game;
  public BallController ball;

  private void Update()
  {
    if (Input.GetKey(KeyCode.S)) // Player left inputs
    {
      playerLeft.GoDown();
    }
    if (Input.GetKey(KeyCode.W))
    {
      playerLeft.GoUp();
    }

    if (Input.GetKey(KeyCode.K)) // Player right inputs
    {
      playerRight.GoDown();
    }
    if (Input.GetKey(KeyCode.I))
    {
      playerRight.GoUp();
    }

    if (Input.GetKeyDown(KeyCode.Space)) // Start Game
    {
      game.StartRound();
    }
  }
}
