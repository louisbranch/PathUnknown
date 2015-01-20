using UnityEngine;
using System.Collections;

public class FadeTiles : MonoBehaviour {

	Transform[] allChildren;

	private void Awake () {
		allChildren = GetComponentsInChildren<Transform>();
		foreach (Transform child in allChildren) {
			if (child.renderer) {
				child.gameObject.tag = "Tile";
				Color color = child.renderer.material.color;
				color.a = 0f;
				child.renderer.material.color = color;
			}
		}
	}

	public void Reveal() {
		foreach (Transform child in allChildren) {
			if (child.gameObject.tag == "Tile") {
				TileFader fader = child.gameObject.GetComponent<TileFader>();
				if (fader) fader.FadeIn();
			}
		}
	}

}