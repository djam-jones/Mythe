using UnityEngine;
using System.Collections;

    // Boy Voesten

public class SwitchPlayer : MonoBehaviour 
{

    public GameObject target01;
    public GameObject target02;
    private PlayerTools _playerTools;
    private GameObject _currentTarget;

    void Start() 
    {
        // TODO: Replace string with a const
        _playerTools = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerTools>();
    }

    // Check who to disable/enable, then send it to the PlayerTools so that it doesn't have to calculate/check anything there
    public void CheckPlayer() 
    {
        //Debug.Log("CheckPlayer");

        _currentTarget = CameraFocus.target;
        // Disable current target
        _playerTools.ToggleMovement(_currentTarget);
        _playerTools.ToggleItemManip(_currentTarget);
        
        // Check who to focus on for the new target
        if (_currentTarget == target01) 
        {
            _playerTools.TogglePlayerFocus(target02);
        }
        else 
        {
            _playerTools.TogglePlayerFocus(target01);
        }
        
        _currentTarget = CameraFocus.target;
        // Enable new target
        _playerTools.ToggleMovement(_currentTarget);
        _playerTools.ToggleItemManip(_currentTarget);
    }

}
