using UnityEngine;
using System.Collections;


namespace SogolDrivingSimulator
{
	[RequireComponent (typeof (Deer))]
	
	public class DeerStop : MonoBehaviour {
		
		// Use this for initialization
		[SerializeField] private Deer _deer;
	    [SerializeField] private Animator _animator;
		
		
		void Start () {
			_deer = GetComponent<Deer> ();

		}
		void Update ()
		{
			_animator.SetBool ("Alive",true);

		}
		
		void OnCollisionEnter(Collision _collision)
		{
			if (_collision.gameObject.name == "Car")
			{
				Debug.Log ("Deer collided with the car");
				_animator.SetBool ("Alive",false);
				_deer.enabled = false;
			}
			
		}
	}
}
