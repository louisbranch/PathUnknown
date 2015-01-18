using UnityEngine;
using System.Collections;

public class MenuOptions : MonoBehaviour {

	public void StartGame () {
		Application.LoadLevel("Level01");
	}

	public void QuitGame () {
		Application.Quit();
	}

}
