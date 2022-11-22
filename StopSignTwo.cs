using UnityEngine;
using System.Collections;

//namespace SogolDrivingSimulator
//{
//[RequireComponent(typeof (New_CarControll))] 

public class StopSignTwo : MonoBehaviour { 
	
	// Use this for initialization
	public static bool HasStopped = false;
	private New_CarControll m_Car;
	private float _carspeed;
	
	void Start () {
		
		m_Car = GetComponent<New_CarControll>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if ( CheckPoints.turntheparticleon == 11) 
		{
			//carspeed = m_Car.CurrentSpeed;
			//Debug.Log ("Car speed is" + _carspeed);
			//if (  _carspeed< 1f )
			//Cheking both the keyboard button and the joystick buttons.
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.DownArrow)||Input.GetKeyDown (KeyCode.JoystickButton1)|| Input.GetAxis("Vertical") < 0)
				
			{
				HasStopped = true; 
				
				Debug.Log ("Stop Sign Script and the index is 11");
			}
		}
		
		
		
	}
}
//}


