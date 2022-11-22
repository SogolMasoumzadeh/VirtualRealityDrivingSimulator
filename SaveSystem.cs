using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem {


	public static void SavePlayer(CheckPoints _cp)
	{
		BinaryFormatter _formatter = new BinaryFormatter ();
		string path = Application.persistentDataPath + "/savedfile.dat";
		FileStream _stream = new FileStream (path, FileMode.Create);

		PlayerData _data = new PlayerData(_cp);

		_formatter.Serialize(_stream,_data);
		_stream.Close();
	}

	public static PlayerData LoadPlayer()
	{
		string path = Application.persistentDataPath + "/savedfile.dat";

		if (File.Exists (path)) {
			BinaryFormatter _formatter = new BinaryFormatter ();
			FileStream _stream = new FileStream (path, FileMode.Open);

			PlayerData _data = _formatter.Deserialize (_stream) as PlayerData;
			_stream.Close ();

			return _data;
		}
		else
		{
			Debug.Log("There is no file in the desired directory");
			Debug.Log (Application.persistentDataPath);
			return  null;
		}



	}
}
