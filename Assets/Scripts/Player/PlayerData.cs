using UnityEngine;
using UnityEngine.UI;
using System.Collections;

    // Boy Voesten

public class PlayerData : MonoBehaviour 
{

    private int _highscore;
    private int _score = 0;
    
    void Awake() 
    {
        DontDestroyOnLoad(this);
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

    public int highscore 
    {
        get 
        {
            return _highscore;
        }
        set
        {
            _highscore = value;
        }
    }
    

}
