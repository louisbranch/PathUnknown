using UnityEngine;
using System.Collections;

[ExecuteInEditMode()]

public class SortTiles : MonoBehaviour {

	private void Update(){
		int order = 0;
		Transform[] allChildren = GetComponentsInChildren<Transform>();
		foreach (Transform child in allChildren) {
			if (child.renderer) {
				child.renderer.sortingOrder = order++;
			}
		}
	}
}