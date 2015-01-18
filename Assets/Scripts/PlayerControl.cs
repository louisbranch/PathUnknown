using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float speed = 1f;
	enum Directions {NW, NE, SW, SE};
	private Directions dir;

	public Transform movementChecker;
	public float checkerRadius = 0.05f;
	public LayerMask hillLayer;
	public LayerMask impassibleLayer;

	private bool atHill = false;
	private float normalAngle = 2.0f;
	private float atHillAngle = 1.2f;
	
	Transform nw;
	Transform ne;
	Transform se;
	Transform sw;

	private bool moveNW = true;
	private bool moveNE = true;
	private bool moveSE = true;
	private bool moveSW = true;

	private Collider2D nwColl;
	private Collider2D neColl;
	private Collider2D swColl;
	private Collider2D seColl;

	Animator anim;

	private void Awake () {
		anim = GetComponent<Animator>();
		nw = transform.Find("NW");
		ne = transform.Find("NE");
		se = transform.Find("SE");
		sw = transform.Find("SW");

		nwColl = transform.Find("NWRevealer").GetComponent<EdgeCollider2D>();
		neColl = transform.Find("NERevealer").GetComponent<EdgeCollider2D>();
		swColl = transform.Find("SWRevealer").GetComponent<EdgeCollider2D>();
		seColl = transform.Find("SERevealer").GetComponent<EdgeCollider2D>();
	}

	private void Update () {

		float angle = atHill ? atHillAngle : normalAngle;

		atHill = Physics2D.OverlapCircle(movementChecker.position, checkerRadius, hillLayer);

		moveNW = !Physics2D.OverlapCircle(nw.position, checkerRadius, impassibleLayer);
		moveNE = !Physics2D.OverlapCircle(ne.position, checkerRadius, impassibleLayer);
		moveSW = !Physics2D.OverlapCircle(sw.position, checkerRadius, impassibleLayer);
		moveSE = !Physics2D.OverlapCircle(se.position, checkerRadius, impassibleLayer);

		float hMove = Input.GetAxis("Horizontal");
		float vMove = Input.GetAxis("Vertical");

		float x = speed * Time.deltaTime;
		float y = speed/angle * Time.deltaTime;

		Directions old = dir;

		if (hMove != 0) {
			if (hMove > 0 && moveSE) {
				transform.Translate(x,-y,0); // bottom right
				dir = Directions.SE;
			} else if (hMove < 0 && moveNW) {
				transform.Translate(-x,y,0); // top left
				dir = Directions.NW;
			}
		} else if (vMove != 0) {
			if (vMove > 0 && moveNE) {
				transform.Translate(x,y,0);  // top right
				dir = Directions.NE;
			} else if (vMove < 0 && moveSW) {
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

	}

	private void EnableCollidersNESW() {

	}

}