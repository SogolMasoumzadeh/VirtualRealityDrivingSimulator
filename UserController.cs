using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


[RequireComponent(typeof (New_CarControll))] 
	public class UserController : MonoBehaviour
	{
		// Using the Car controll class for this script

		//[SerializeField] private float drift_time = 3f;
		//[SerializeField] private float Dist_Threshold = 20f;

		private New_CarControll m_Car; 

		//private Vector3 check_Point, drift_point;
		//private Quaternion checkpoint_rot, driftpoint_rot;
	//	private float drifiting_timer;
	//	private bool is_drifiting = false;
		//private float time_ratio;
		//private Rigidbody Rb;
		// Using Awake function as not any of the variables have been set
		private void Awake()
		{
			// get the car controller
			m_Car = GetComponent<New_CarControll>();
			//get initial position and initial rotation
			//check_Point = transform.position;
			//checkpoint_rot = transform.rotation;
		}

		//private void StartDrfiting()
		//{
			//is_drifiting = true;
			//drifiting_timer = 0f;
			//drift_point = transform.position;
			//driftpoint_rot = transform.rotation;                                           

			//Rb = GetComponent <Rigidbody>();
			//if (Rb != null)
			//{
			//	Rb.velocity = Vector3.zero;
			//	Rb.constraints = RigidbodyConstraints.None;
		//	}
		//}

		//private void StopDrfiting()
		//{
		//	is_drifiting = false;
			//transform.position = check_Point;
			//transform.rotation = checkpoint_rot;
		//}
		
		// Using fixed update for physics simulation will be more realistic
		// The input is passed to the vehicle through arrow keys or i.e.
		// The arrow keys are the input

		private void FixedUpdate()
		{
			// pass inputs to the car!
			// Vertical axis as steering
			float h = CrossPlatformInputManager.GetAxis ("Horizontal");

			// Vertical axis as accelerating and decelerating using the brake
			float v = CrossPlatformInputManager.GetAxis("Vertical");

			//#if !MOBILE_INPUT
			// The jump or space is the handbrake
			float handbrake = CrossPlatformInputManager.GetAxis("Jump");
			//
			m_Car.MovingTheCar(h, v, v, handbrake); 
		
			//#else
			//m_Car.MovingTheCar(h, v, v, 0f);
			//#endif

		} // end of the fixed update

		//private void LateUpdate()
		//{
		//	if (Vector3.Distance(check_Point, transform.position) > Dist_Threshold)
			//	StartDrfiting();
			//if (is_drifiting)
			//{
				//drifiting_timer += Time.deltaTime;
			//	if (drifiting_timer > drift_time)
				//	StopDrfiting();
				//else
				//{
					//time_ratio = drifiting_timer / drift_time;
					//transform.position = Vector3.Lerp(drift_point, check_Point, time_ratio);
					//transform.rotation = Quaternion.Lerp(driftpoint_rot, checkpoint_rot, time_ratio);

				//} // end of the else
			//}// end of the if (is_drifiting)
		//} // end of the LateUpdate
	} // end of the public class of the user controll

