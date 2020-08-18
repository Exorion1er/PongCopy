using UnityEngine;

public class BallController : MonoBehaviour {
	public GameController game;

	public string playerTag;
	public string worldTag;
	public string loseTag;
	public float baseMoveSpeed;
	public float speedUpMultiplier;
	public float maxSpeed;

	private Vector2 velocity;

	public void FirstPush() {
		Push(Random.Range(1, 3) == 1 ? Direction.left : Direction.right);
	}

	public void Push(Direction dir) {
		float x = dir == Direction.left ? baseMoveSpeed : -baseMoveSpeed;
		velocity = new Vector2(x, 0);
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == playerTag) {
			Vector2 newDirection = (transform.position - collision.transform.position).normalized;
			velocity = newDirection * velocity.magnitude * speedUpMultiplier;
		}
		if (collision.tag == worldTag) {
			velocity.Set(velocity.x, -velocity.y);
		}
		if (collision.tag == loseTag) {
			game.Score(collision.GetComponent<LoseWall>().position, transform.position);
		}
	}

	private void Update() {
		if (velocity.magnitude > maxSpeed) {
			velocity = Vector2.ClampMagnitude(velocity, maxSpeed);
		}

		transform.position += (Vector3)velocity * Time.deltaTime;
	}

	public void Reset() {
		transform.position = Vector2.zero;
		velocity = Vector2.zero;
	}
}
