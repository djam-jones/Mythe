using UnityEngine;
using UnityEngine.UI;
using System.Collections;

    // Boy Voesten

public class PlayerScore : MonoBehaviour 
{

    public Text scoreTxt;
    public bool counting = true;
    private PlayerData _playerData;

    void Start() 
    {
        _playerData = GameObject.FindGameObjectWithTag(AllTagsConstants.playerData).GetComponent<PlayerData>();
        scoreTxt.text = "Time: " + _playerData.score;
    }

    void Update() 
    {
        if (counting) 
        {
            _playerData.score = Mathf.RoundToInt(Time.timeSinceLevelLoad);
            scoreTxt.text = "Time: " + _playerData.score;
        }
    }
}
