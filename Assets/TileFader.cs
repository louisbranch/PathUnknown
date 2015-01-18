using UnityEngine;
using System.Collections;

public class TileFader : MonoBehaviour {

	private bool fadeIn =  false;
	private bool fadeOut = false;
	
	private float counter;

	Transform[] allChildren;

	private void Awake() {
		allChildren = GetComponentsInChildren<Transform>();
	}

	private void Update () {
		if (fadeIn || fadeOut) {

			foreach (Transform child in allChildren) {
				Color color = renderer.material.color;
				if (fadeIn) {
					color.a = 1f;
					child.renderer.material.color = Color.Lerp(child.renderer.material.color, 
					                                           color, Time.deltaTime * 5f);
				} else {
					color.a = 0;
					child.renderer.material.color = Color.Lerp(child.renderer.material.color, 
					                                           color, Time.deltaTime * 5f);
				}
			}


		}
	}

	public void FadeIn() {
		fadeIn = true;
		fadeOut = false;
	}

	public void FadeOut() {
		fadeIn = false;
		fadeOut = true;
	}
}
