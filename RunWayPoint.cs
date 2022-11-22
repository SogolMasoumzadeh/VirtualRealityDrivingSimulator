using UnityEngine;
using System.Collections;

namespace SogolDrivingSimulator
{
	//[RequireComponent(typeof (New_CarControll))] 
	public class RunWayPoint : MonoBehaviour {

	// Use this for initialization

		//public float CollisonCheckDistance;
		//public bool aboutToCollide;
		//public float DistanceToCollide;
		[SerializeField] private float CollideThreshold = 0f;
		[SerializeField]private Transform[] WayPoints = new Transform[4];
		[SerializeField] private float Movement_Speed = 10f;
		[SerializeField] private float Rotat_Speed = 2f;
		private Rigidbody rb;
		private int Current_point = 0;
		private float Radious = 1f;
		private float _Distance;
		private Vector3 InitialDistance;
		private bool RunAI = true;

	
	void Start () {
			rb = GetComponent<Rigidbody> ();
			InitialDistance = transform.position;
	}
	
	// Update is called once per frame
	

		void Update()
		{
			if (Vector3.Distance(InitialDistance, GameObject.Find ("Car").transform.position) < CollideThreshold && RunAI )
			 
			{
				_Distance = Vector3.Distance (WayPoints [Current_point].position, transform.position);
				if (_Distance < Radious)
				{
					Current_point += 1;

				}
				transform.position = Vector3.MoveTowards(transform.position,WayPoints[Current_point].position, Time.deltaTime * Movement_Speed);
				transform.rotation = Quaternion.LookRotation(WayPoints[Current_point].position - transform.position, Vector3.up);
			}

			if (Vector3.Distance (WayPoints [WayPoints.Length-1].position, transform.position)< Radious)
			{
				Current_point =0;
				rb.velocity =Vector3.zero;
				RunAI = false;
				
			}
		}// end of void update



		void OnCollisionEnter(Collision _collison)
		{
			if (_collison.gameObject.name == "Car")
			{
				rb.velocity = Vector3.zero;
			}
		}
	}// end of class mono behaviour
}