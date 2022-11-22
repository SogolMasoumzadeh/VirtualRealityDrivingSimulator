using UnityEngine;
using System.Collections;


namespace SogolDrivingSimulator
{
	[RequireComponent (typeof (RunWayPoint))]
	
	public class OponentStop : MonoBehaviour {
		
		// Use this for initialization
		[SerializeField] private RunWayPoint _runwaypoint;


		void Start () {

			_runwaypoint = GetComponent < RunWayPoint> ();
		}

		void OnCollisionEnter(Collision _collision)
		{
			Debug.Log ("Collision with player Happened");
			_runwaypoint.enabled = false;

		}
	}
}
