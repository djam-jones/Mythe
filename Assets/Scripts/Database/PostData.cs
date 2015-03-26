﻿using UnityEngine;
using System.Collections;

    // Boy Voesten

public class PostData : MonoBehaviour 
{

    private string _username;
    private int _highscore;
    private PlayerData _playerData;

    void Start() 
    {
        _playerData = GameObject.FindGameObjectWithTag(AllTagsConstants.playerData).GetComponent<PlayerData>();
    }

    public void Submit() 
    {
        // Check if username is entered.
        if (_username == null || _username.Length < 1) 
        {
            Debug.Log("Invalid Username");
            return;
        }

        // Get highscore
        _highscore = Mathf.RoundToInt(_playerData.highscores[_playerData.currentLvl]);
        Post();
    }

    public void Post() 
    {
        string url = "http://localhost/bap/inputoutput.php";
        WWWForm form = new WWWForm();

        form.AddField("username", _username);
        form.AddField("_highscore", _highscore);

        WWW www = new WWW(url, form);
        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www) 
    {
        yield return www;

        // check for errors
        if (www.error == null) 
        {
            // Connection successfull
            Debug.Log("WWW Ok!: " + www.text);
        }
        else 
        {
            // Connection could not be made
            Debug.Log("WWW Error: " + www.error);
        }

        // Continue to the next level, even if you fail to connect to database
        Application.LoadLevel(Application.loadedLevel +1);
    }

    // For the UI to set
    public string user 
    {
        set 
        {
            _username = value;
        }
    }

}