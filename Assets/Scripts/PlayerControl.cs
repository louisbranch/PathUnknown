using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float speed = 1f;
	enum Directions {NW, NE, SW, SE};
	private Directions dir;

	private bool upHill = false;
	private float normalAngle = 2.0f;
	private float upHillAngle = 1.2f;
	
	TilesRevealer northColl;
	TilesRevealer westColl;
	TilesRevealer southColl;
	TilesRevealer eastColl;

	Animator anim;

	private void Awake () {
		anim = GetComponent<Animator>();
		northColl = transform.Find("North").GetComponent<TilesRevealer>();
		westColl = transform.Find("West").GetComponent<TilesRevealer>();
		southColl = transform.Find("South").GetComponent<TilesRevealer>();
		eastColl = transform.Find("East").GetComponent<TilesRevealer>();
	}

	private void Update () {

		float angle = upHill ? upHillAngle : normalAngle;

		float hMove = Input.GetAxis("Horizontal");
		float vMove = Input.GetAxis("Vertical");

		float x = speed * Time.deltaTime;
		float y = speed/angle * Time.deltaTime;

		Directions old = dir;

		if (hMove != 0) {
			if (hMove > 0) {
				transform.Translate(x,-y,0); // bottom right
				dir = Directions.SE;
			} else {
				transform.Translate(-x,y,0); // top left
				dir = Directions.NW;
			}
		} else if (vMove != 0) {
			if (vMove > 0) {
				transform.Translate(x,y,0);  // top right
				dir = Directions.NE;
			} else {
				transform.Translate(-x,-y,0); // bottom left
				dir = Directions.SW;
			}
		}

		if (dir != old) {
			ChangeDirection();
		}

	}

	private void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.name == "Hill") {
			FlipRotation();
		}
	}

	private void ChangeDirection() {
		switch (dir) {
		case Directions.NW:
			anim.CrossFade("PlayerNW", 0.5f);
			EnableCollidersNWSE();
			break;
		case Directions.SE:
			anim.Play("PlayerSE");
			EnableCollidersNWSE();
			break;
		case Directions.NE:
			anim.Play("PlayerNE");
			EnableCollidersNESW();
			break;
		case Directions.SW:
			anim.Play("PlayerSW");
			EnableCollidersNESW();
			break;
		}
	}

	private void EnableCollidersNWSE() {
		northColl.enabled = true;
		southColl.enabled = true;
		westColl.enabled = false;
		eastColl.enabled = false;
	}

	private void EnableCollidersNESW() {
		northColl.enabled = false;
		southColl.enabled = false;
		westColl.enabled = true;
		eastColl.enabled = true;
	}

	private void FlipRotation() {
		upHill = !upHill;
	}

}