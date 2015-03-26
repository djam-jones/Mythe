using UnityEngine;
using UnityEngine.UI;
using System.Collections;

    // Boy Voesten

public class PlayerData : MonoBehaviour 
{

    private float[] _highscores = new float[4];
    private int _score = 0;
	private int _unlockedLevels = 1;
    private int _currentLvl;
    SaveLoadDataSerialized _saveLoadData;

    private static bool spawned = false;
    
    void Awake() 
    {
        if (spawned == false) {
            spawned = true;

            DontDestroyOnLoad(transform.gameObject);

        } else {
            DestroyImmediate(gameObject); //This deletes the new objects that might be created
        }

        _saveLoadData = GameObject.FindGameObjectWithTag(AllTagsConstants.saveLoadData).GetComponent<SaveLoadDataSerialized>();
    }

    public void CheckScore() 
    {
        Debug.Log("CheckScore -> Trigger");

        if (_score < _highscores[_currentLvl]) {
            Debug.Log("Score < Highscore");
            _highscores[_currentLvl] = _score;
            Debug.Log("New Highscore: " + _highscores[_currentLvl]);
        }
        SaveHighscore();

        if (_currentLvl + 1 == _unlockedLevels) {
            _unlockedLevels++;
        }
    }

    public void SaveHighscore() 
    {
        _highscores[_currentLvl] = _score;
        Debug.Log("SaveHighscore - " + _score + " - Into -> " + _highscores[_currentLvl]);
        _saveLoadData.Save();
    }

    public float GetHighscore(int lvlNumber) 
    {
        return _highscores[lvlNumber];
    }

    void OnApplicationFocus(bool focus) 
    {
        if (!focus) 
        {
            _saveLoadData.Save();
        }
    }

    // GETTERS & SETTERS

    public float[] highscores 
    {
        get 
        {
            return _highscores;
        }
        set 
        {
            _highscores = value;
        }
    }

    public int score
    {
        get 
        {
            return _score;
        }
        set 
        {
            _score = value;
        }
    }

	public int unlockedLevels
	{
		get
		{
			return _unlockedLevels;
		}
		set
		{
			_unlockedLevels = value;
		}
	}

    public int currentLvl 
    {
        get 
        {
            return _currentLvl;
        }
        set 
        {
            _currentLvl = value;
        }
    }
}
