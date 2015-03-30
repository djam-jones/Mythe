using UnityEngine;
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
        if (_username == null || _username.Length <= 2) 
        {
            Debug.Log("Invalid Username, must be longer than 2 chars");
            return;
        }

        Post();
    }

    public void Post() 
    {
        string url = "http://projectprologue.com/mythe/inputoutput.php";
        WWWForm form = new WWWForm();

        form.AddField("username", _username);

        // Put all lvls' highscores into the url. 
        // PHP will grab it and automatically put it into an array.
        for (var i = 0; i < _playerData.highscores.Length; i++) 
        {
            _highscore = Mathf.RoundToInt(_playerData.highscores[i]);
            form.AddField("highscore[]", _highscore);
        }

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