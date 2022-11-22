using UnityEngine;
using System.Collections;

public class TutorialManegr : MonoBehaviour {

	// Use this for initialization
	public GameObject[] popups = new GameObject[5];
	private int popupIndex = 0;
	private float timepassed = 0f;
	private bool end = false;

	void Start()
	{
		Debug.Log ("Deactivating pupops initially");

		for (int i = 0; i< popups.Length; i ++) {
			popups[i].SetActive (false);
			Debug.Log ("Deactivating pupops");
		}
		popups [popupIndex].SetActive (true);

	}


	void Update()
	{

			timepassed += Time.deltaTime;
			if (timepassed > 5.0f) {
				timepassed = 0f;
				popups [popupIndex].SetActive (false);
				popupIndex += 1;
				if (popupIndex == popups.Length)
				{
					end = true; 
					popupIndex = 0;
					Debug.Log ("Current index is " + popupIndex + " boolian is " + end);
				    Debug.Log ("Now we will load the next level for you");
					Application.LoadLevel("Level1.Backup");



				} // second if
			if (end == false)
			{
				popups [popupIndex].SetActive (true);
				Debug.Log ("Activating the game object index " + popupIndex + " boolian is " + end);

			} // boolian if

			} // first if



	}
//	void Update()
//	{
//		for (int i = 0; i < popups.Length; i++)
//		{
//			popups[i].SetActive(true);
//			timepassed += Time.deltaTime;
//			//if (Input.GetAxis("Vertical") > 0)
//			if (timepassed > 5.0f)
//			{
//				timepassed = 0f;
//				popups[i].SetActive(false);
//			}
////			if (i == popupIndex)
////				popups[i].SetActive(true);
////			else
////				popups[popupIndex].SetActive(false);
//
//		}

		// If the participant can appreciate going forward
//		if (popupIndex == 0)
//		{
//			timepassed += Time.deltaTime;
//			//if (Input.GetAxis("Vertical") > 0)
//			if (timepassed > 5.0f)
//			{
//				timepassed = 0f;
//				popupIndex +=1; 
//			}
//		} // index == 0
//
//
//		// If the participant can appreciate going backward
//		if (popupIndex == 1)
//		{
//			//if (Input.GetAxis("Vertical") < 0)
//			if (timepassed > 5.0f)
//			{
//				timepassed = 0f;
//				popupIndex +=1; 
//			}		
//		} // index == 1



//		// If the participant can appreciate stopping
//		if (popupIndex == 2)
//		{
//			//if (Input.GetKeyDown (KeyCode.JoystickButton1))
//			if (timepassed > 5.0f)
//			{
//				timepassed = 0f;
//				popupIndex +=1; 
//			}
//		} // index == 2
//
//
//		// If the participant can appreciate turning the wheel
//		if (popupIndex == 3)
//		{
//			//if (Input.GetAxis ("Horizontal") > 0 || Input.GetAxis ("Horizontal") < 0)
//			if (timepassed > 5.0f)
//			{
//				Application.LoadLevel ("Level1.Backup");
//
//			}
//		} // index == 2

	}// void update

