using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrafficLightSix : MonoBehaviour {
	
	// Use this for initialization
	enum states
	{	first,
		Green,
		Red
	}
	[SerializeField] private Renderer GreenLight;
	[SerializeField] private Renderer RedLight;
	
	private states CurrentState;
	private float CurrentTime;
	public static string _statetwo;
	public static bool _IsBreakingtwo = false;
	
	
	private void start()
	{
		RedLight = GetComponent<Renderer>();
		GreenLight = GetComponent<Renderer> ();
		CurrentState = states.Red;
		CurrentTime = Time.time;
	}
	
	private void Update()
	{
		switch (CurrentState) {
			
		case states.first:
			
			Green_state ();
			if (Vector3.Distance (GameObject.Find ("Car").transform.position, transform.position) < 30f){
				CurrentState = states.Red;
				CurrentTime = 0.0f;
				
			}
			
			break;
		case states.Red:
			
			Red_state ();
			if (CurrentTime > 10.0f){
				CurrentState = states.Green;
				CurrentTime = 0.0f;
			}
			
			break;
		case states.Green:
			
			Green_state();
			if (CurrentTime > 10.0f)
			{
				CurrentState  = states.Red;
				CurrentTime = 0.0f;
			}
			break;
		} // end of the switch
	} // end of the Update 
	
	private void Red_state()
	{
		CurrentTime += Time.deltaTime;
		RedLight.material.color = Color.red;
		GreenLight.material.color = Color.black;
		_statetwo = "Red";
		Debug.Log ("The state is red");
		//Cheking both the keyboard button and the joystick buttons.
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.DownArrow)||Input.GetKeyDown (KeyCode.JoystickButton1)|| Input.GetAxis("Vertical") < 0)
			
		{
			Debug.Log("Joystick is working");
			_IsBreakingtwo = true;
		}
		
	}
	
	private void Green_state()
	{
		CurrentTime += Time.deltaTime;
		GreenLight.material.color = Color.green;
		RedLight.material.color = Color.black;
		_statetwo = "Green";
		Debug.Log ("The state is green");
		
		
		
	}
}