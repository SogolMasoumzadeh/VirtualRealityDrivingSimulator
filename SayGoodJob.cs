using UnityEngine;
using System.Collections;

public class SayGoodJob : MonoBehaviour {

	// Use this for initialization
	public GameObject GoodJobMenueUI;
	private float _passedTime;
	public static bool flag = false;
	void Start () {
		if (Application.loadedLevel == 2)
			GoodJobMenueUI.SetActive (false);

	
	}
	
	// Update is called once per frame
	void Update () {
		if (!flag) {
			if (CheckPoints.turntheparticleon == 17) {
		//if (Input.GetKeyDown(KeyCode.Backspace))
				Debug.Log ("We are in the say goodbye");
				GoodJobMenueUI.SetActive (true);
				_passedTime += Time.deltaTime;


				if (_passedTime > 5.0f)
				{
					Application.LoadLevel ("MainMenue");
					flag =true;
				}


			}
	
		} // if (! falg)

		if (flag){

			GoodJobMenueUI.SetActive (false);
		}
	} // void update
}
