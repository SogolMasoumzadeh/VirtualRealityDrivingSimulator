using UnityEngine;
using System.Collections;

public class Patrolloing : Istates{

	private GameObject Owner;
	private GameObject[] Points;
	private int current_point;
	private NavMeshAgent Agent;
	public bool DoPatrolling =true;

	public Patrolloing(GameObject _owner, GameObject[] _points,  int _currentpoint, NavMeshAgent _agent)
	{
		Owner = _owner;
		Points = _points;
		current_point = _currentpoint;
		Agent = _agent;
	}

	public void Entre()
	{
		Agent.autoBraking = false;
	}

	public void Exection()
	{

			if (Points.Length == 0)
				return;
			if (!Agent.pathPending && Agent.remainingDistance < 0.5f) {
				Agent.destination = Points [current_point].transform.position;
				current_point = (current_point + 1) % Points.Length;

		}
	}

	public void Exit()
	{
		//if (current_point == Points.Length-1) {
			//Debug.Log ("Shit is Running");
			//Owner.GetComponent<NavMeshAgent> ().Stop ();
	//}
}
}
