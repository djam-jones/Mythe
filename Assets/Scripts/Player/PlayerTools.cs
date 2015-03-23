using UnityEngine;
using System.Collections;

    // Boy Voesten
    // This script basically splits the calls to either currentTarget or the oldTarget, which is calculated by the switchPlayer script
    // Todo: Improve this code

public class PlayerTools : MonoBehaviour 
{

    public GameObject defaultTarget;
    private GameObject _currentTarget;
    private PlayerMovement _playerMovement;
    private CameraFocus _cameraFocus;

    void Start()
    {
        _cameraFocus = GameObject.FindGameObjectWithTag(AllTagsConstants.MainCamera).GetComponent<CameraFocus>();
        _cameraFocus.target = defaultTarget;
        _playerMovement = defaultTarget.GetComponentInChildren<PlayerMovement>();
    }
    
    // Toggle PlayerMovement
    public void ToggleMovement(GameObject target) 
    {
        _playerMovement = target.GetComponentInChildren<PlayerMovement>();
        _playerMovement.enabled = !_playerMovement.enabled;
    }

    // Toggle ItemManipulation
    public void ToggleItemManip(GameObject target) 
    {
        if (!target.GetComponentInChildren<ObjectManipulation>()) return;
        ObjectManipulation objectManipulation;
        objectManipulation = target.GetComponentInChildren<ObjectManipulation>();
        objectManipulation.enabled = !objectManipulation.enabled;
    }

    // Toggle Camera's focus between players
    public void TogglePlayerFocus(GameObject target) 
    {
        _currentTarget = target;
        _cameraFocus.target = _currentTarget;
    }

    // Update Player's PlayerMovement
    public void UpdateMovement(float _offsetX) 
    {
        _playerMovement.offsetX = _offsetX;
    }

}
