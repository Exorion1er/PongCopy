using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float moveSpeed;
	public float heightLimit;

	private Vector2 basePos;

	private void Start() {
		basePos = transform.position;
	}

	public void GoDown() {
		transform.Translate(-transform.up * moveSpeed * Time.deltaTime);
		if (transform.position.y < -heightLimit) {
			transform.position = new Vector3(transform.position.x, -heightLimit, transform.position.z);
		}
	}

	public void GoUp() {
		transform.Translate(transform.up * moveSpeed * Time.deltaTime);
		if (transform.position.y > heightLimit) {
			transform.position = new Vector3(transform.position.x, heightLimit, transform.position.z);
		}
	}

	public void Reset() {
		transform.position = basePos;
	}
}
