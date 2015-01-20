using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
	
	public Text gui;
	public Text timeOver;
	public AudioClip hurry;
	public AudioClip death;
	public AudioClip win;

	public GameObject tiles;

	private AudioSource aSource;
	private PlayerControl player;

	public int timer = 60;
	private float counter = 0;
	private bool won = false;
	
	private void Awake() {
		player = GetComponent<PlayerControl>();
		aSource = GetComponent<AudioSource>();
	}

	private void Start() {
		counter = Time.time;
	}

	private void Update () {
		float now = Time.time;

		if ((now - counter) < 1f || won) {
			return;
		}

		--timer;

		if (timer >= 0) {
			gui.text = FormatTime(timer);
		}

		switch (timer) {
		case 10:
			Hurry();
			break;
		case 0:
			TimeUp();
			break;
		case -3:
			GameControl.LifeLost();
			break;
		}

		counter = now;
	}

	public void WinGame() {
		won = true;
		aSource.PlayOneShot(win);
		tiles.GetComponent<FadeTiles>().Reveal();
		Invoke("SaveScore", 3f);
	}

	private void SaveScore() {
		GameControl.WinLevel(timer);
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

	private void Hurry() {
		gui.color = new Color(1f, 0, 0);
		aSource.PlayOneShot(hurry);
	}

	private void TimeUp () {
		player.paused = true;
		timeOver.enabled = true;
		aSource.PlayOneShot(death);
		if (GameControl.CurrentLives() == 1) {
			tiles.GetComponent<FadeTiles>().Reveal();
		}
	}

}