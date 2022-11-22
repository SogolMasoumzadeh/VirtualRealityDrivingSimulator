using UnityEngine;
using System.Collections;


namespace SogolDrivingSimulator
{
[RequireComponent (typeof (New_CarControll))]

public class StopPlayer : MonoBehaviour {

	// Use this for initialization
		[SerializeField] private New_CarControll _CarControll;
		[SerializeField] private UserController  _UserCont;
		private New_CarControll _mcar;

		[SerializeField] private float CollisionBreak = 1000f;
		private New_CarControll m_car;

	void Start () {
			_CarControll = GetComponent < New_CarControll> ();
			_UserCont = GetComponent<UserController >();
			_mcar = GetComponent<New_CarControll>();
		

	}
	
	void OnCollisionEnter(Collision _collision)
		{
			Debug.Log ("Collision with Oponent Happened");
			_mcar.MovingTheCar (0f, 0f, 0f, 1e+8f);
			_CarControll.enabled = false;
			_UserCont.enabled = false;

		}
	void LateUpdate()
		{
			_CarControll.enabled = true;
			_UserCont.enabled = true;
		}



	}
}
