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

	[HideInInspector] public bool paused = false;

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
	
	Animator anim;
	Timer timer;

	private void Awake () {
		anim = GetComponent<Animator>();
		timer = GetComponent<Timer>();
		nw = transform.Find("NW");
		ne = transform.Find("NE");
		se = transform.Find("SE");
		sw = transform.Find("SW");
	}

	private void Update () {
		if (paused) return;

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
		if (name == "Goal") {
			paused = true;
			timer.WinGame();
		}
	}

	private void ChangeDirection() {
		//TODO include up and down hill animations
		string animation = "Player";
		switch (dir) {
		case Directions.NW:
			animation += "NW";
			break;
		case Directions.SE:
			animation += "SE";
			break;
		case Directions.NE:
			animation += "NE";
			break;
		case Directions.SW:
			animation += "SW";
			break;
		}
		anim.Play(animation);
	}

}