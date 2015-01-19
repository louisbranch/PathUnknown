using UnityEngine;
using System.Collections;

public class FadeTiles : MonoBehaviour {

	private void Awake () {
		Transform[] allChildren = GetComponentsInChildren<Transform>();
		foreach (Transform child in allChildren) {
			if (child.renderer) {
				child.gameObject.tag = "Tile";
				Color color = child.renderer.material.color;
				color.a = 0f;
				child.renderer.material.color = color;
			}
		}
	}

}