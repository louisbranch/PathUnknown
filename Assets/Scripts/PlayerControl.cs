using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float speed = 1f;

	private void Update () {

		float hMove = Input.GetAxis("Horizontal");
		float vMove = Input.GetAxis("Vertical");

		float x = speed * Time.deltaTime;
		float y = speed/2 * Time.deltaTime;

		if (hMove != 0) {
			if (hMove > 0) {
				transform.Translate(x,-y,0); // bottom right
			} else {
				transform.Translate(-x,y,0); // top left
			}
		} 

		if (vMove != 0) {
			if (vMove > 0) {
				transform.Translate(x,y,0);  // top right
			} else {
				transform.Translate(-x,-y,0); // bottom left
			}
		}

	}

}