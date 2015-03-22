using UnityEngine;
using UnityEngine.UI;
using System.Collections;

    // Boy Voesten

public class PlayerScore : MonoBehaviour 
{

    public Text scoreTxt;
    public bool counting = true;
    private PlayerData playerData;

    void Start() 
    {
        playerData = GameObject.FindGameObjectWithTag(AllTagsConstants.playerData).GetComponent<PlayerData>();
        scoreTxt.text = "Time: " + playerData.score;
    }

    void Update() 
    {
        if (counting) 
        {
            playerData.score = Mathf.RoundToInt(Time.timeSinceLevelLoad);
            scoreTxt.text = "Time: " + playerData.score;
        }
    }
}
