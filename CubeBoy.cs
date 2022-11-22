using UnityEngine;
using System.Collections;

[RequireComponent (typeof(NavMeshAgent))]

public class CubeBoy : MonoBehaviour {

	// Use this for initialization
	StateMachine _statemachine = new StateMachine();

	[SerializeField]private GameObject goal;
	private NavMeshAgent agent;
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		_statemachine.ChangeStates (new SearchFor( gameObject, goal, agent));
	}
	
	// Update is called once per frame
	void Update () {
		_statemachine.ExecuteStatesUpdate ();
	
	}
}
