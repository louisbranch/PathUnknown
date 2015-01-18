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
				//child.renderer.enabled = false;
				child.renderer.sortingOrder = order++;
			}
		}
	}
}
