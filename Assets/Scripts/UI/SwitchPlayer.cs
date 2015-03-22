using UnityEngine;
using System.Collections;

    // Boy Voesten

public class SwitchPlayer : MonoBehaviour 
{

    public GameObject target01;
    public GameObject target02;
    public GameObject uiJump;
    private PlayerTools _playerTools;
    private GameObject _currentTarget;
    private CameraFocus _cameraFocus;

    void Start() 
    {
        _cameraFocus = GameObject.FindGameObjectWithTag(AllTagsConstants.MainCamera).GetComponent<CameraFocus>();
        _playerTools = GameObject.FindGameObjectWithTag(AllTagsConstants.gameManagerTag).GetComponent<PlayerTools>();
    }

    // Check who to disable/enable, then send it to the PlayerTools so that it doesn't have to calculate/check anything there
    public void CheckPlayer() 
    {   
        _currentTarget = _cameraFocus.target;
        // Disable current target
        _playerTools.ToggleMovement(_currentTarget);
        _playerTools.ToggleItemManip(_currentTarget);
        
        // Check who to focus on for the new target
        if (_currentTarget == target01) 
        {
            _playerTools.TogglePlayerFocus(target02);
            uiJump.SetActive(false);
        }
        else 
        {
            _playerTools.TogglePlayerFocus(target01);
            uiJump.SetActive(true);
        }
        
        _currentTarget = _cameraFocus.target;
        // Enable new target
        _playerTools.ToggleMovement(_currentTarget);
        _playerTools.ToggleItemManip(_currentTarget);
    }

}
