using UnityEngine;
using System.Collections;

public class MenuOptions : MonoBehaviour {

	public AudioClip click;

	AudioSource aSource;

	private void Awake() {
		aSource = GetComponent<AudioSource>();
	}

	public void StartGame () {
		aSource.PlayOneShot(click);
		Application.LoadLevel("Level01");
	}

	public void MainMenu () {
		aSource.PlayOneShot(click);
		Application.LoadLevel("Menu");
	}

	public void QuitGame () {
		aSource.PlayOneShot(click);
		Application.Quit();
	}

}
