using UnityEngine;
using System.Collections;



internal enum Speed_type
	{
		MPH,
		KPH
	}

public class Run : MonoBehaviour {

	// Use this for initialization
	[SerializeField]private Speed_type SpeedType;
	[SerializeField] private float _mMasxSpeed= 10f ;
	[SerializeField] private GameObject[] Points = new GameObject[3];
	private int current_point = 0;
	private NavMeshAgent _agent;
	void Start () {
		_agent = GetComponent<NavMeshAgent> ();
		_agent.autoBraking = false;

		GoToNextPoint ();
		
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<NavMeshAgent> ().enabled = true;
		if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
			GoToNextPoint ();
	
	}
	void LateUpdate()
	{
		if (current_point == Points.Length-1) {
			Debug.Log ("Shit is Running");
			//gameObject.GetComponent<NavMeshAgent>().Stop ();


		}

	}


	void GoToNextPoint()
	{
		if (Points.Length == 0)
			return;
		MaxSpeed ();
		//gameObject.GetComponent<NavMeshAgent> ().speed = _mMasxSpeed ;
		_agent.destination = Points [current_point].transform.position;
		//current_point = (current_point + 1)% Points.Length;
		current_point = (current_point + 1)%(Points.Length);
		 

	}
		void MaxSpeed()
		{
			switch (SpeedType)
			{
			case Speed_type.KPH:
				gameObject.GetComponent<NavMeshAgent> ().speed = _mMasxSpeed * 3.6f;

			break;
			case Speed_type.MPH:
				gameObject.GetComponent<NavMeshAgent> ().speed = _mMasxSpeed * 2.23693629f;
			break;

			}
		}
}
