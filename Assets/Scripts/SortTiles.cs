using UnityEngine;
using System.Collections;
using UnityEngine;

[ExecuteInEditMode()]

public class SortTiles : MonoBehaviour {

	private void Update(){
		int order = 0;
		Transform[] allChildren = GetComponentsInChildren<Transform>();
		foreach (Transform child in allChildren) {
			if (child.renderer) {
				Color color = child.renderer.sharedMaterial.color;
				color.a = 1f;
				child.renderer.sharedMaterial.color = color;
				child.renderer.sortingOrder = order++;
			}
		}
	}

	private void Awake () {
		Transform[] allChildren = GetComponentsInChildren<Transform>();
		foreach (Transform child in allChildren) {
			if (child.renderer) {
				child.gameObject.tag = "Tile";
				Color color = child.renderer.sharedMaterial.color;
				color.a = 0f;
				child.renderer.sharedMaterial.color = color;
			}
		}
	}
}
