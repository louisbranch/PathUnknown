using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerDisplay : MonoBehaviour {
	
	private Text gui;

	private int timer = 60;
	private float counter = 0;

	private void Awake() {
		gui = GetComponent<Text>();
	}

	private void Start() {
		counter = Time.time;
	}

	private void Update () {
		float now = Time.time;

		if ((now - counter) > 1f) {
			--timer;
			gui.text = FormatTime();
			counter = now;
		}

		if (timer == 0) {
			GameControl.LifeLost();
		}
	}

	public int FinalTime() {
		return timer;
	}

	private string FormatTime () {
		//FIXME mm:ss
		int mins = timer / 60;
		int secs = timer % 60;
		string m;
		string s;
		if (mins < 10) {
			m = "0" + mins;
		} else {
			m = mins.ToString();
		}
		if (secs < 10) {
			s = "0" + secs;
		} else {
			s = secs.ToString();
		}
		return m + ":" + s;
	}

}