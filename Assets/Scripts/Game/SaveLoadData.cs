using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadData : MonoBehaviour {

	private ToBeSavedData toBeSavedData;

	void Awake () 
	{
		toBeSavedData = gameObject.GetComponent<ToBeSavedData>();	
	}

	public void Save ()
	{
		BinaryFormatter binaryFormatter = new BinaryFormatter ();
		FileStream file = File.Create(Application.persistentDataPath + "/SaveData.dat");

		SaveData saveData = new SaveData ();
		saveData.gold = toBeSavedData.GetGold ();

		binaryFormatter.Serialize (file, saveData);
		file.Close ();
		Debug.Log ("Saved");
	}

	public void Load()
	{
		if (File.Exists(Application.persistentDataPath + "/SaveData.dat"))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/SaveData.dat", FileMode.Open);

			SaveData savedData = (SaveData)binaryFormatter.Deserialize(file);
			toBeSavedData.SetGold(savedData.gold);
			Debug.Log ("Loaded");
		}

	}
}

[System.Serializable]
public class SaveData
{
	public int gold;
}
