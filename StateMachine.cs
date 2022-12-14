using UnityEngine;
using System.Collections;

public class StateMachine : MonoBehaviour {

	private Istates CurrentState;
	private Istates PreviousState;

	public void ChangeStates(Istates newstate)
	{
		if (CurrentState != null)
			CurrentState.Exit ();

		PreviousState = CurrentState;
		CurrentState = newstate;
		CurrentState.Entre ();
	}

	//When this method is run do whatever the currently state wants to do
	public void ExecuteStatesUpdate()
	{
		if (CurrentState != null)
		CurrentState.Exection();

	}

	//
	public void SwitchToPrevious()
	{
		CurrentState.Exit ();
		CurrentState = PreviousState;
		CurrentState.Entre ();
	}
}
