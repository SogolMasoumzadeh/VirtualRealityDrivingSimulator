using UnityEngine;
using System.Collections;

public class PauseMenue : MonoBehaviour {

	public static bool GameIsPaused = false;
	public GameObject PauseMenuUI;

	// Update is called once per frame
	void Update ()
	{
	 if (Input.GetKeyDown (KeyCode.Escape))
		{
			if(GameIsPaused)
				Resume();
			else
				Pause();
		}
	}

	public void Resume()
	{
		PauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		GameIsPaused = false;

	}

	void Pause()
	{
		//Bringing the pause menue
		PauseMenuUI.SetActive (true);

		//Freez the time
		Time.timeScale = 0f;

		GameIsPaused = true;
	}

	public void LoadMainMenue()
	{
		Time.timeScale = 1f;
		Application.LoadLevel ("MainMenue");
	}

	public void QuitGame()
	{
		Debug.Log ("Quiting the game");
		Application.Quit ();

	}
}
