using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {
	
	private static int lives = 3;
	private static bool paused = false;
	private static bool won = false;
	private static int currentLives = lives;

	void Start () {
		Screen.showCursor = false; 
		won = false;
	}
	
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.LoadLevel("Menu");
			Screen.showCursor = true;
		}

		if (Input.GetButtonDown("Pause")) {
			if (paused) {
				Time.timeScale = 0f;
			} else {
				Time.timeScale = 1f;
			}
			paused = !paused;
		}

	}

	public static bool Won() {
		return won;
	}

	public static void WinLevel(int time) {
		won = true;
		SaveHighscore(time);
		GameOver();
	}

	public static int TotalLives() {
		return lives;
	}

	public static int CurrentLives() {
		return currentLives;
	}

	public static void LifeLost() {
		--currentLives;
		ReloadLevel();
	}

	private static void ReloadLevel() {
		if (currentLives == 0) {
			GameOver();
		} else {
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	private static void SaveHighscore(int score) {
		for (int i = 0; i < 5; i++) {
			int current = PlayerPrefs.GetInt("highscore_" + i);
			if (score > current) {
				PlayerPrefs.SetInt("highscore_" + i, score);
				score = current; // move value down the chain
			} else if (score == current) {
				break;
			}
		}
	}

	private static void GameOver() {
		currentLives = lives;
		Application.LoadLevel("GameOver");
		Screen.showCursor = true;
	}

}