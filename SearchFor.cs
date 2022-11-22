using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SearchFor : Istates {


	GameObject Owner;
	GameObject goal;
	NavMeshAgent NavigationAgent;

	public SearchFor(GameObject _owner,GameObject _goal ,NavMeshAgent _navigationagent)
	{

		Owner = _owner;
		goal = _goal;
		NavigationAgent = _navigationagent;
	}
	public void Entre()
	{

	}

	public void Exection ()
	{
		NavigationAgent.SetDestination(goal.transform.position); 

		
	}
	public void  Exit() 
	{

	}
}
