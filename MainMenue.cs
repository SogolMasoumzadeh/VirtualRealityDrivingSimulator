using UnityEngine;
using System.Collections;

public class MainMenue : MonoBehaviour {

	// Use this for initialization
	public void PlayLevelOne()
	{
		Application.LoadLevel ("How2Drive");
	}

	public void PlayLevelTwo()
	{
		Application.LoadLevel ("Level2.Backup");
	}

	public void PlayLevelThree()
	{
		Application.LoadLevel ("Level3.Backup");
	}

	public void QuitGame()
	{
		Debug.Log ("Quit");
		Application.Quit ();
	}
}
