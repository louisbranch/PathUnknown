using UnityEngine;
using System.Collections;

public class TilesRevealer : MonoBehaviour {

	public bool enabled = false;

	private void OnTriggerEnter2D (Collider2D coll) {
		if (enabled && coll.gameObject.name == "Grass") {
			coll.gameObject.renderer.enabled = true;	
		}
	}
	
	private void OnTriggerStay2D (Collider2D coll) {
		if (enabled && coll.gameObject.name == "Grass") {
			coll.gameObject.renderer.enabled = true;	
		}
	}

	private void OnTriggerExit2D (Collider2D coll) {
		if (coll.gameObject.name == "Grass") {
			coll.gameObject.renderer.enabled = false;	
		}
	}
}
