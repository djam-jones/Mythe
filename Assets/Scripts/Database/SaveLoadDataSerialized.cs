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

        // Save game data into the save file
        Debug.Log("Saving -> Highscores");
        saveData.highscores = _playerData.highscores;
        Debug.Log("Saving -> UnlockedLvls");
        saveData.unlockedLvls = _playerData.unlockedLevels;

        // Encrypt the file
        binaryFormatter.Serialize(file, saveData);

        file.Close();

        Debug.Log("~ Saved Data ~");
    }

    public void Load() 
    {
        if (File.Exists(Application.persistentDataPath + "/SaveData.dat")) 
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SaveData.dat", FileMode.Open);

            // Decrypt the file
            SaveData savedData = (SaveData)binaryFormatter.Deserialize(file);

            // Load saved data into the game
            Debug.Log("Loading -> savedData.highscores");
            _playerData.highscores = savedData.highscores;
            Debug.Log("Loading -> savedData.UnlockedLvls");
            _playerData.unlockedLevels = savedData.unlockedLvls;

            file.Close();

            Debug.Log("~ Loaded Data ~");        
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
    public int unlockedLvls;

}