using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float speed = 1f;
	enum Directions {NW, NE, SW, SE};
	private Directions dir;

	private void Update () {

		float hMove = Input.GetAxis("Horizontal");
		float vMove = Input.GetAxis("Vertical");

		float x = speed * Time.deltaTime;
		float y = speed/2 * Time.deltaTime;

		Directions old = dir;

		if (hMove != 0) {
			if (hMove > 0) {
				transform.Translate(x,-y,0); // bottom right
				dir = Directions.SE;
			} else {
				transform.Translate(-x,y,0); // top left
				dir = Directions.NW;
			}
		} 

		if (vMove != 0) {
			if (vMove > 0) {
				transform.Translate(x,y,0);  // top right
				dir = Directions.NE;
			} else {
				transform.Translate(-x,-y,0); // bottom left
				dir = Directions.SW;
			}
		}

		if (dir != old) {
			Debug.Log (dir);
		}

	}

}