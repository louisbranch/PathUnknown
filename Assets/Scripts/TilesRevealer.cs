using UnityEngine;
using System.Collections;

public class TilesRevealer : MonoBehaviour {
	
	private void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Tile") {
			coll.gameObject.GetComponent<TileFader>().FadeIn();
		}
	}
	
	private void OnTriggerStay2D (Collider2D coll) {
		if (coll.gameObject.tag == "Tile") {
			coll.gameObject.GetComponent<TileFader>().FadeIn();
		}
	}

	private void OnTriggerExit2D (Collider2D coll) {
		if (coll.gameObject.tag == "Tile") {
			coll.gameObject.GetComponent<TileFader>().FadeOut();
		}
	}
}
