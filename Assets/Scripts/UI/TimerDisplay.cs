using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerDisplay : MonoBehaviour {
	
	public Text gui;
	public Text timeOver;
	public AudioClip hurry;
	public AudioClip death;

	private AudioSource aSource;

	public int timer = 60;
	private float counter = 0;
	
	private void Awake() {
		aSource = GetComponent<AudioSource>();
	}

	private void Start() {
		counter = Time.time;
	}

	private void Update () {
		float now = Time.time;

		if ((now - counter) < 1f) {
			return;
		}

		--timer;

		if (timer >= 0) {
			gui.text = FormatTime(timer);
		}

		if (timer == 10) {
			aSource.PlayOneShot(hurry);
		} else if (timer == 0) {
			timeOver.enabled = true;
			aSource.PlayOneShot(death);
		} else if (timer < 0) {
			GameControl.LifeLost();
		}

		counter = now;
	}

	public int FinalTime() {
		return timer;
	}

	public static string FormatTime (int time) {
		int mins = time / 60;
		int secs = time % 60;
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