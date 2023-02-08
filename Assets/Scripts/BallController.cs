using UnityEngine;

public class BallController : MonoBehaviour
{
  public GameController game;

  public string playerTag;
  public string worldTag;
  public string loseTag;
  public float baseMoveSpeed;
  public float speedUpMultiplier;
  public float maxSpeed;

  private Vector2 velocity;

  private void Update()
  {
    if (velocity.magnitude > maxSpeed)
    {
      velocity = Vector2.ClampMagnitude(velocity, maxSpeed);
    }

    transform.position += (Vector3)velocity * Time.deltaTime;
  }

  public void FirstPush()
  {
    Push(Random.Range(1, 3) == 1 ? Direction.left : Direction.right);
  }

  public void Push(Direction dir)
  {
    float x = dir == Direction.left ? baseMoveSpeed : -baseMoveSpeed;
    velocity = new Vector2(x, 0);
  }

  public void Reset()
  {
    transform.position = Vector2.zero;
    velocity = Vector2.zero;
  }
}
