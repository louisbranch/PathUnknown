using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float speed = 1f;
	enum Directions {NW, NE, SW, SE};
	private Directions dir;

	public Transform movementChecker;
	public float checkerRadius = 0.1f;
	public LayerMask hillLayer;

	private bool atHill = false;
	private float normalAngle = 2.0f;
	private float atHillAngle = 1.2f;
	
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

		float angle = atHill ? atHillAngle : normalAngle;

		atHill = Physics2D.OverlapCircle(movementChecker.position, checkerRadius, hillLayer);

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
		string name = coll.gameObject.name;
		if (name == "Water") {
		}
	}

	private void ChangeDirection() {
		string animation = "Player";
		switch (dir) {
		case Directions.NW:
			animation += "NW";
			EnableCollidersNWSE();
			break;
		case Directions.SE:
			animation += "SE";
			EnableCollidersNWSE();
			break;
		case Directions.NE:
			animation += "NE";
			EnableCollidersNESW();
			break;
		case Directions.SW:
			animation += "SW";
			EnableCollidersNESW();
			break;
		}
		anim.Play(animation);
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

}