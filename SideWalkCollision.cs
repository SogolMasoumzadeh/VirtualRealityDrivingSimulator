using UnityEngine;
using System.Collections;

public class SideWalkCollision : MonoBehaviour {

	// Use this for initialization
	public static int CollisionCounter = 0;
	private float CollidingTime;
	private CheckPoints _chechpoint;
	void Start () {
		_chechpoint = GetComponent<CheckPoints> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision _collision)
	{
		if (_collision.gameObject.name == "Car") 
		{
			Debug.Log("Car collided with the sidewalk");
			CollisionCounter +=1;
			//Debug.Log(CollisionCounter);
			FindObjectOfType<MangerAudio>().Play("crash");

		}
	}

	//void onCollisionStay(Collision _collision)
	//{
		//if (_collision.gameObject.name == "Car") 
		//{
			 //CollidingTime += Time.deltaTime;
			//if (CollidingTime > 10.0f) 
			//{
				//GameObject.Find ("Car").transform.position = Vector3.MoveTowards (GameObject.Find ("Car").transform.position, WayPoints [Current_point].position, Time.deltaTime * Movement_Speed);

			//}
			
		//}

	//}
}
