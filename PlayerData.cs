using UnityEngine;
using System.Collections;
[System.Serializable]
public class PlayerData {

	// Use this for initialization
	public int CheckPointIndex;
	private float _time;
	public float _Time 
	{
		get 
		{
			return _time;
		}
		set
		{
			_time = value;
		}
	}

	public PlayerData(CheckPoints _cp)
	{
		CheckPointIndex = _cp.Index;
		_time = _cp._Time;

	}
}
