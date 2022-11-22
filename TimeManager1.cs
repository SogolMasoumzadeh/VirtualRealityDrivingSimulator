
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TimeManager1 : MonoBehaviour {

	// Use this for initialization
	[SerializeField] private static int _minute;
	[SerializeField] private static int _second;
	[SerializeField] private static float _millisec;
	[SerializeField] private static string _millitext;

	[SerializeField] private GameObject _minutebox;
	[SerializeField] private GameObject _secondbox;
	[SerializeField] private GameObject _millibox;


	void Start () {
		if (Application.loadedLevel == 2 || Application.loadedLevel == 3 || Application.loadedLevel == 4)
		{
			_millisec = 0;
			_second = 0;
			_minute = 0;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		_millisec += Time.deltaTime * 10 ;
		_millitext = _millisec.ToString("F0");
		_millibox.GetComponent<Text> ().text = "" +_millitext;

		if (_millisec > 9)
		{
			_millisec = 0;
			_second +=1;
		}

		if (_second <= 9) 
		{ 
			_secondbox.GetComponent<Text>().text = "0" + _second + ".";
		}
		else
		{
			_secondbox.GetComponent<Text>().text = "" + _second + ".";
			
		}

		if (_second > 59) 
		{
			_second = 0;
			_minute += 1;
		
		}

		if (_minute <= 9) 
		{
			_minutebox.GetComponent<Text> ().text = "0" + _minute + ":";
		} 
		else 
		{
			_minutebox.GetComponent<Text> ().text = "" + _minute + ":";

		}
	
	}
}
