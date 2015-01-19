using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerDisplay : MonoBehaviour {

	public AudioClip hurry;
	public AudioClip death;

	public Text gui;
	private AudioSource audio;

	private int timer = 60;
	private float counter = 0;

	private bool hurryUp = false;

	private void Awake() {
		gui = GetComponent<Text>();
		audio = GetComponent<AudioSource>();
	}

	private void Start() {
		counter = Time.time;
	}

	private void Update () {
		float now = Time.time;

		if ((now - counter) > 1f) {
			--timer;
			gui.text = FormatTime(timer);
			counter = now;
		}

		if (timer <= 10 && !hurryUp) {
			audio.PlayOneShot(hurry);
			hurryUp = true;
		}

		if (timer == 0) {
			audio.PlayOneShot(death);
		}

		if (timer < 0) {
			GameControl.LifeLost();
		}
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