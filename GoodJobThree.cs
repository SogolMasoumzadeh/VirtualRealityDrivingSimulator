using UnityEngine;
using System.Collections;

public class GoodJobThree : MonoBehaviour {
	
	// Use this for initialization
	public GameObject GoodJobMenueUI;
	private float _passedTime;
	public static bool flag = false;

	void Start () {
		if (Application.loadedLevel == 4)
			GoodJobMenueUI.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!flag) {
			if (CheckPoints.turntheparticleon == 30) {
			//if (Input.GetKeyDown(KeyCode.Backspace))
				Debug.Log ("We are in the say goodbye");
				GoodJobMenueUI.SetActive (true);
				_passedTime += Time.deltaTime;
				if (_passedTime > 5.0)
				{
					Application.LoadLevel ("MainMenue");
					flag = true;
				} // if the _passedTime
			
			
			
			} // checkpoint 
		}// if (!flag)

		if (flag)
			GoodJobMenueUI.SetActive (false);
	} // void update
}
