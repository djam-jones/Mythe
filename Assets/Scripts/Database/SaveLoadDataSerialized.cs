using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

    // Boy Voesten

public class SaveLoadDataSerialized : MonoBehaviour 
{

    private PlayerData _playerData;

    void Awake() 
    {
        _playerData = GameObject.FindGameObjectWithTag(AllTagsConstants.playerData).GetComponent<PlayerData>();
    }

    public void Save() 
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SaveData.dat");

        SaveData saveData = new SaveData();
        saveData.highscores = _playerData.highscores;

        binaryFormatter.Serialize(file, saveData);
        file.Close();
        Debug.Log("Saving -> " + saveData.highscores);
        Debug.Log("Saved Data");

        for (int i = 0; i < _playerData.highscores.Length; i++) 
        {
            Debug.Log("ClientData: " + i + " - " + _playerData.highscores[i]);
            Debug.Log("SaveData: " + i + " - " + saveData.highscores[i]);
        }
    }

    public void Load() 
    {
        if (File.Exists(Application.persistentDataPath + "/SaveData.dat")) 
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SaveData.dat", FileMode.Open);

            SaveData savedData = (SaveData)binaryFormatter.Deserialize(file);
            _playerData.highscores = savedData.highscores;

            file.Close();
            Debug.Log("Loading -> " + savedData.highscores);
            Debug.Log("Loaded Data");

            for (int i = 0; i < _playerData.highscores.Length; i++) 
            {
                Debug.Log("ClientData: " + i + " - " + _playerData.highscores[i]);
                Debug.Log("LoadedData: " + i + " - " + savedData.highscores[i]);
            }
        }
        else 
        {
            Debug.Log("Save Data doesn't exist");
        }
        
    }
}


[System.Serializable]
public class SaveData 
{

    public float[] highscores = new float[4];

}