using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float speed = 1f;
	enum Directions {NW, NE, SW, SE};
	private Directions dir;

	
	TilesRevealer North;
	TilesRevealer West;
	TilesRevealer South;
	TilesRevealer East;

	private void Awake () {
		North = transform.Find("North").GetComponent<TilesRevealer>();
		West = transform.Find("West").GetComponent<TilesRevealer>();
		South = transform.Find("South").GetComponent<TilesRevealer>();
		East = transform.Find("East").GetComponent<TilesRevealer>();
	}

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
			ChangeColliders();
		}

	}

	private void ChangeColliders() {
		switch (dir) {
		case Directions.NW:
		case Directions.SE:
			North.enabled = true;
			South.enabled = true;
			West.enabled = false;
			East.enabled = false;
			break;
		case Directions.NE:
		case Directions.SW:
			North.enabled = false;
			South.enabled = false;
			West.enabled = true;
			East.enabled = true;
			break;
		}
	}

}