using UnityEngine;
using System.Collections;

public class PlayThem : MonoBehaviour {

	// Use this for initialization
     
	[SerializeField]private GameObject[] _system;

	void Awake () {
		_system [0].SetActive (false);
		_system [1].SetActive (false);
		//Debug.Log ("OK?");

	}
	
	// Update is called once per frame
	void Update () {
		if ( CheckPoints.turntheparticleon == 17) 
		//if ( CheckPoints.turntheparticleon== 3) 
		{
			for (int i=0; i< _system.Length; i++)
			{
			//if(_system[i].isPlaying)
			//_system[i].SetActive (false);
		    _system[i].SetActive (true);
			Debug.Log("Activated");

			}
		}
	} // void update
}
