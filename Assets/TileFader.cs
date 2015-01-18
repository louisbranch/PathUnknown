using UnityEngine;
using System.Collections;

public class TileFader : MonoBehaviour {

	private bool fadeIn =  false;
	private bool fadeOut = false;
	
	private float counter;

	private void Update () {
		if (fadeIn || fadeOut) {
			Color color = renderer.material.color;
			if (fadeIn) {
				color.a = 1f;
				renderer.material.color = Color.Lerp(renderer.material.color, color, Time.deltaTime * 5f);
			} else {
				color.a = 0;
				renderer.material.color = Color.Lerp(renderer.material.color, color, Time.deltaTime * 5f);
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
