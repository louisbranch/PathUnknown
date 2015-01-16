using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	private float speed = 0.1f;
	private float move = 0.5f;
	private float half = 0.25f;
	private float counter;

	private void Start () {
		counter = Time.time;
	}

	private void Update () {

		if ((Time.time - counter) < speed) return;

		float hMove = Input.GetAxis("Horizontal");
		float vMove = Input.GetAxis("Vertical");

		if (hMove != 0) {
			if (hMove > 0) {
				transform.Translate(move,-half,0); // bottom right
			} else {
				transform.Translate(-move,half,0); // top left
			}

			counter = Time.time;
		} else if (vMove != 0) {
			if (vMove > 0) {
				transform.Translate(move,half,0);  // top right
			} else {
				transform.Translate(-move,-half,0); // bottom left
			}

			counter = Time.time;
		}

	}

}