using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverDisplay : MonoBehaviour {

	private void Awake() {
		Text gui = GetComponent<Text>();
		if (GameControl.CurrentLives() == 1) {
			gui.text = "Game Over!";
		}
	}

}
