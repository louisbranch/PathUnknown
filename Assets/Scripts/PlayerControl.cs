using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float speed = 1f;

	private void Update () {
		float hMove = Input.GetAxis("Horizontal");
		float vMove = Input.GetAxis("Vertical");

		if (hMove != 0) {
			int direction = hMove > 0 ? 1 : -1;
			transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
			transform.Translate(Vector2.up * -direction * speed * Time.deltaTime);
		} else if (vMove != 0) {
			int direction = vMove > 0 ? 1 : -1;
			transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
			transform.Translate(Vector2.up * direction * speed * Time.deltaTime);
		}
	}

}