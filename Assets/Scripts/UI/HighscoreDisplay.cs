using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighscoreDisplay : MonoBehaviour {

	private void Awake () {
		Text gui = GetComponent<Text>();
		int time = PlayerPrefs.GetInt("highscore");
		gui.text = TimerDisplay.FormatTime(time);
	}
}