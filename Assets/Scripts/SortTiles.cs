using UnityEngine;
using UnityEditor;
using System.Collections;

public class SortTiles : MonoBehaviour {

	private void Awake(){
		int order = 0;
		Transform[] allChildren = GetComponentsInChildren<Transform>();
		foreach (Transform child in allChildren) {
			if (child.renderer) {
				child.gameObject.tag = "Tile";
				Color color = child.renderer.material.color;
				color.a = 0f;
				child.renderer.material.color = color;
				child.renderer.sortingOrder = order++;
			}
		}
	}
}
