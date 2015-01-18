using UnityEngine;
using System.Collections;

public class SortTiles : MonoBehaviour {

	private void Awake(){
		int order = 0;
		Transform[] allChildren = GetComponentsInChildren<Transform>();
		foreach (Transform child in allChildren) {
			if (child.renderer) child.renderer.sortingOrder = order++;
		}
	}
}
