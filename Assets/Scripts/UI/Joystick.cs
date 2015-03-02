using UnityEngine;
using System.Collections;

    // Boy Voesten

public class Joystick : MonoBehaviour 
{

    private Vector2 _mousePosition;
    private Vector2 _originalPos;
    private PlayerTools _playerTools;
    private float _range = 0.54f;
    private float _pivotToObj;
    private bool _move;
    private float _offsetX;
    public float moveSpeed = 0.1f; 

    void Start() 
    {
        // TODO: Replace string with a const
        _playerTools = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerTools>();
        _originalPos = transform.parent.position;
    }

    public void Drag(bool move) 
    {
        _move = move;
    }

    public void FixedUpdate() 
    {

        _originalPos = transform.parent.position;

        _mousePosition = Input.mousePosition;
        _mousePosition = Camera.main.ScreenToWorldPoint(_mousePosition);

        float distance = (_mousePosition - _originalPos).magnitude;
        float pivotToObj = ((Vector2)transform.position - _originalPos).magnitude;


        if (_move) 
        {
            if (distance <= _range) 
            {
                transform.position = _mousePosition;
            }
            else 
            {
                Vector2 step = _mousePosition - _originalPos;
                step.Normalize();
                step *= _range;

                transform.position = _originalPos + step;
            }
        }
        else 
        {
            transform.position = Vector2.Lerp(transform.position, _originalPos, moveSpeed * 2);
        }

        // This will prevent the values from going crazy when trying to return to it's original position
        if (pivotToObj > 0.1f) 
        {
            pivotToObj = ((Vector2)transform.position - _originalPos).magnitude;
            _offsetX = (transform.position.x - _originalPos.x) / _range;
        }
        else 
        {
            pivotToObj = 0;
            _offsetX = 0;
        }

        //Debug.Log("OffsetX: " + _offsetX);

        // Send the info to the PlayerTools which then sets it, I don't want this script to know who's the current target
        _playerTools.UpdateMovement(_offsetX);
    }

}
