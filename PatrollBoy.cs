using UnityEngine;
using System.Collections;

public class PatrollBoy : MonoBehaviour {

	// Use this for initialization

	StateMachine _statemachine = new StateMachine();

	[SerializeField] private GameObject[] Points = new GameObject[2];
	private int current_point;
	private NavMeshAgent agent;
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		_statemachine.ChangeStates (new Patrolloing(gameObject,Points, current_point, agent));
	
	}
	
	// Update is called once per frame
	void Update () {

		_statemachine.ExecuteStatesUpdate ();
		//_statemachine.StiwchToPrevious ();

	}
	void LateUpdate () {
	
	}
}


