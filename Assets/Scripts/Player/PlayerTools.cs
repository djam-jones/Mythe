using UnityEngine;
using System.Collections;

    // Boy Voesten
    // This script basically splits the calls to either currentTarget or the oldTarget, which is calculated by the switchPlayer script
    // Todo: Improve this code (Quickly written for prototype)

public class PlayerTools : MonoBehaviour 
{

    public GameObject defaultTarget;
    private GameObject _currentTarget;
    private PlayerMovement _playerMovement;

    void Start()
    {
        CameraFocus.target = defaultTarget;
        _playerMovement = defaultTarget.GetComponentInChildren<PlayerMovement>();
    }
    
    public void ToggleMovement(GameObject target) 
    {
        _playerMovement = target.GetComponentInChildren<PlayerMovement>();
        _playerMovement.enabled = !_playerMovement.enabled;
        //Debug.Log("ToggleMovement");
    }

    public void ToggleItemManip(GameObject target) 
    {
        if (!target.GetComponentInChildren<ManipulationPoints>()) return;
        ManipulationPoints manipulationPoints;
        manipulationPoints = target.GetComponentInChildren<ManipulationPoints>();
        manipulationPoints.enabled = !manipulationPoints.enabled;
        //Debug.Log("ToggleItemManip");
    }

    public void TogglePlayerFocus(GameObject target) 
    {
        _currentTarget = target;
        CameraFocus.target = _currentTarget;
        //Debug.Log("TogglePlayerFocus");
    }

    public void UpdateMovement(float _offsetX) 
    {
        _playerMovement.offsetX = _offsetX;
    }

}
