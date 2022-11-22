using UnityEngine;
using System.Collections;
using System.IO;
using SimpleJSON;
//RequireComponent(typeof (CheckPoints))]  
public class CheckpointSystem : MonoBehaviour {

	// Use this for initialization
	[SerializeField] private CheckPoints[] _checkpoints;
	public int NumberofCP;
	private int _currentIndex = 0 ;
	public int currentIndex 
	{
		get
		{ 
			return _currentIndex;
		}
		 set
		{
			_currentIndex = value;
		}

	}

	//[SerializeField] private CheckPoints _test;
	void Start () {
		//_test = GetComponent<CheckPoints>();
		//_test.Index = 0;
		//_test.mysystem = this;
		_checkpoints = GetComponentsInChildren<CheckPoints> ();
		NumberofCP = _checkpoints.Length;

		for (int i = 0; i < NumberofCP; i++)
		{
			_checkpoints[i].gameObject.SetActive(true);
			_checkpoints[i].Index = i;
			_checkpoints[i].mysystem = this;
			//_checkpoints[i].Save();
			if (i == 18)
			{
				Debug.Log("You are in the wrong rout");
			}

		}
	


	}
	
}
