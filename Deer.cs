using UnityEngine;
using System.Collections;

namespace SogolDrivingSimulator
{
	//[RequireComponent(typeof (New_CarControll))] 
	public class Deer : MonoBehaviour {
		
		// Use this for initialization
		
		//public float CollisonCheckDistance;
		//public bool aboutToCollide;
		//public float DistanceToCollide;
		[SerializeField] private float CollideThreshold = -5f;
		[SerializeField] private Transform[] WayPoints = new Transform[4];
		[SerializeField] private float Movement_Speed = 10f;
		[SerializeField] private float Rotat_Speed = 2f;
		[SerializeField]private Animator _animator;
		private float StopTheRun = 30f;

		//[SerializeField]private Animation _animation;
		private Rigidbody rb;
		private Collider cl;
		private int Current_point = 0;
		private float Radious = 1f;
		private float _Distance;
		private Vector3 InitialDistance;
		private float relative_dis;
		private bool RunAI = true;
		//private bool _isalive =true;

		void Start () {
			rb = GetComponent<Rigidbody> ();
			cl = GetComponent<Collider> ();
			InitialDistance = transform.position;
			_animator.SetBool ("Alive", true);
			_animator.SetFloat ("Run", CollideThreshold + 100);

			
			
		}
		
		// Update is called once per frame
		
		
		void Update()
		{   


			_animator.SetBool ("Alive", true);
			//_animator.SetFloat ("Run", CollideThreshold + 1);
			float relative_dis = Vector3.Distance (InitialDistance, GameObject.Find ("Car").transform.position);

			if (relative_dis < CollideThreshold && RunAI) {
					_animator.SetFloat ("Run", relative_dis);
					_Distance = Vector3.Distance (WayPoints [Current_point].position, transform.position);
				//	Debug.Log ("Distance? " + _Distance);
					if (_Distance < Radious ) {
						Current_point += 1;

					//transform.position = Vector3.MoveTowards (transform.position, WayPoints [Current_point].position, Time.deltaTime * Movement_Speed);
					//transform.rotation = Quaternion.LookRotation (WayPoints [Current_point].position - transform.position, Vector3.up);
					}


					Debug.Log ("Index" + Current_point);
					//Current_point += 1;

					transform.position = Vector3.MoveTowards (transform.position, WayPoints [Current_point].position, Time.deltaTime * Movement_Speed);
					transform.rotation = Quaternion.LookRotation (WayPoints [Current_point].position - transform.position, Vector3.up);
				}

			if (Vector3.Distance (WayPoints [WayPoints.Length-1].position, transform.position)< Radious)
			{
				Current_point = 0;
				RunAI = false;
				Debug.Log (RunAI);

			}

			if (!RunAI || relative_dis > CollideThreshold)
			{

				Debug.Log ("Lenght"+ WayPoints.Length );

				rb.velocity =Vector3.zero;
				//_isrunning = false;
				Debug.Log ("stop animation");
				_animator.SetFloat("Run", StopTheRun);
				//_animator.Play("Idle",-1,0f);
				
			}
		}// end of void update


	
	}// end of class mono behaviour
}