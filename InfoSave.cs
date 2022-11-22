using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using SimpleJSON;


public class InfoSave : MonoBehaviour {

	public InputField InputCode;
	public static string InputText;

		public void Save()
		{
			//Creating the Json file
			InputText = InputCode.text;
			JSONObject playerJson = new JSONObject ();
			playerJson.Add ("Name of the player", InputText);

			
			//Testing the Json file Creation
			//	Debug.Log (playerJson.ToString());
			
			//Saving the Json file
			string path  = Application.persistentDataPath + "/PlayerInfo " +" " + InputText;
			File.WriteAllText(path, playerJson.ToString());
			//File.AppendAllText(path, playerJson.ToString());
		Debug.Log (InputText);
		}


}
