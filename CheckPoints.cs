using UnityEngine;
using System.Collections;
using System.IO;
using SimpleJSON;

public class CheckPoints : MonoBehaviour {

	// Use this for initialization
	public string PlayerName;
	public  int Index;
	public static int turntheparticleon;
	public  CheckpointSystem mysystem;
	private float _time = 0f; 
	private float TimeLag = 0f;
	public float result = 0f;
	//InfoSave _infosave = new InfoSave();
	private int  _firstRow;

	private SideWalkCollision _SideCollision;
	//private MangerAudio _manager;

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


	void Start()
	{
		//_infosave = GetComponent<InfoSave> ();
		TimeLag = Time.time;
		//_manager = GetComponent<MangerAudio>();

		//_SideCollision = GetComponent<SideWalkCollision>();
	}

	void OnTriggerEnter(Collider _other)
	{
		if (_other.gameObject.CompareTag("Player"))
		{

			PlayerName = _other.gameObject.name;
			_time = Time.time;
			 result = _time - TimeLag;
			Debug.Log ("Player entered the triger" +Index + "at time" +  result);
			GotoNextCheckpoint(Index);
			//if (Index == 0)
			//{
				//Debug.Log("The index is zero");
				//SaveHeader();
				//Save();

			//}
			//else
			//{
				Save();

			//}
			SideWalkCollision.CollisionCounter = 0;
			turntheparticleon = Index;

		
			//Wrongwayaudio(Index);

//			if (Application.loadedLevel == 2)
//			{
//				if (Index == 17)
//				{
//					Debug.Log("MainWrongWay");
//					_manager.Play("wrongway");
//				}// If Index == 17
//			}//Application loaded level

		}
	} // void ontrigger enter
	void GotoNextCheckpoint(int i)
	{
		if (i == mysystem.currentIndex)
		{
			mysystem.currentIndex = (mysystem.currentIndex + 1) % mysystem.NumberofCP;


		}
	}

//	void Wrongwayaudio(int i)
//	{
//		if (i == 16)
//			FindObjectOfType <MangerAudio> ().Play ("wrongway");
//		 
//	}



	public void SaveHeader()
	{
		StreamWriter sw;
		FileInfo fi;
		string _filename = InfoSave.InputText;
		//Debug.Log ("Line 61" + _filename);
		//string _filename = "Test3";
		
		fi = new FileInfo ("C:\\Users\\VRN\\Desktop\\VirtualDrvingSimulatorData\\" + "Log" +_filename + ".csv" );
		sw = fi.AppendText ();

		sw.WriteLine ("Index,Time,Crashes,X,Y,Z,Light,IsBreaking");
		sw.Close();
		Debug.Log ("Save header is working");
		//Debug.Log("We are in the if");
		
		//} 
		

		
		//Creating the Json file
		//JSONObject playerJson = new JSONObject ();
		//playerJson.Add ("Name of the player", PlayerName);
		//playerJson.Add ("Index", Index);
		//playerJson.Add ("Passed Time", _Time); 
		
		
		//Testing the Json file Creation
		//	Debug.Log (playerJson.ToString());
		
		//Saving the Json file
		//string path  = Application.persistentDataPath + "/SavedDataCheckPoint " + Index.ToString() +" " + PlayerName;
		//File.WriteAllText(path, playerJson.ToString());
		//File.AppendAllText(path, playerJson.ToString());
		
	}





	public void Save()
	{
		StreamWriter sw;
		FileInfo fi;
		string _filename = InfoSave.InputText;
		//Debug.Log ("Line 61" + _filename);
		//string _filename = "Test3";

		fi = new FileInfo ("C:\\Users\\masoumzs\\Desktop\\VirtualDrvingSimulatorData\\" + "Log" +_filename + ".csv" );
		sw = fi.AppendText ();
		//if (_firstRow == 0) {
		//	sw.WriteLine ("Index,TimePassed,NumberofCrashes");
			//Debug.Log(_firstRow);
			//sw.Close();
			//Debug.Log("We are in the if");

		//} 

		//else 
		//{//
			if (Application.loadedLevel == 2) {
				sw.WriteLine(Index + "," + result + "," + SideWalkCollision.CollisionCounter + "," + GameObject.Find ("Car").transform.position.x + "," + GameObject.Find ("Car").transform.position.y + ","+ GameObject.Find ("Car").transform.position.z + "," +TrafficLightScript._state + "," + TrafficLightScript._IsBreaking + "," + StopSign.HasStopped+ ",");
		}
			
			else if (Application.loadedLevel == 3){
				sw.WriteLine(Index + "," + result + "," + SideWalkCollision.CollisionCounter + "," + GameObject.Find ("Car").transform.position.x + "," + GameObject.Find ("Car").transform.position.y + ","+ GameObject.Find ("Car").transform.position.z + "," +TrafficLightThree._state + "," + TrafficLightThree._IsBreaking + "," + StopSignTwo.HasStopped+ "," + TrafficLightTwo._statetwo + "," + TrafficLightTwo._IsBreakingtwo);
		}
		else
		{
			sw.WriteLine(Index + "," + result + "," + SideWalkCollision.CollisionCounter + "," + GameObject.Find ("Car").transform.position.x + "," + GameObject.Find ("Car").transform.position.y + ","+ GameObject.Find ("Car").transform.position.z + "," +TrafficLightFour._state + "," + TrafficLightFour._IsBreaking + "," + StopSignThree.HasStopped+ "," + TrafficLightFive._statetwo + "," + TrafficLightFive._IsBreakingtwo + "," + TrafficLightSix._statetwo + "," + TrafficLightSix._IsBreakingtwo + "," + StopSignFour.HasStopped);


		}
			sw.Close();
			Debug.Log(GameObject.Find ("Car").transform.position);
			Debug.Log("This is the boolina first row " +_firstRow);
		//}

		//Creating the Json file
		//JSONObject playerJson = new JSONObject ();
		//playerJson.Add ("Name of the player", PlayerName);
		//playerJson.Add ("Index", Index);
		//playerJson.Add ("Passed Time", _Time); 
	

		//Testing the Json file Creation
	//	Debug.Log (playerJson.ToString());

		//Saving the Json file
		//string path  = Application.persistentDataPath + "/SavedDataCheckPoint " + Index.ToString() +" " + PlayerName;
		//File.WriteAllText(path, playerJson.ToString());
		//File.AppendAllText(path, playerJson.ToString());

	}


	//public void Load()
	//{
	//	string path  = Application.persistentDataPath + "/SavedDataCheckPoint " + Index.ToString();
	//	string JsonString = File.ReadAllText (path);
	//	JSONObject Player = (JSONObject)JSON.Parse (JsonString);
	//	Index = Player["Index"];
	//	_Time = Player["Passed Time"];
	//}
	void Update()
	{

	}
	
}
