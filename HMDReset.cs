using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class HMDReset : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.H))

			InputTracking.Recenter ();
	}
}
