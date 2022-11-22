using UnityEngine;
using System.Collections;

public class TutorialMenue : MonoBehaviour {

	public void TutorialOne()
	{
		Application.LoadLevel ("Tutorial1.Backup");
	}

	public void TutorialTwo()
	{
		Application.LoadLevel ("Tutorial2.Backup");
	}

	public void TutorialThree()
	{
		Application.LoadLevel ("Tutorial3.Backup");
	}

}
