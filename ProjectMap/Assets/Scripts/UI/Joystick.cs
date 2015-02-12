using UnityEngine;
using System.Collections;

public class Joystick : MonoBehaviour 
{

    private Vector2 mousePosition;
    private Vector2 originalPos;
    public float moveSpeed = 0.1f;
    private bool move;

    public float jXaxis;
    public float jYaxis;
    private float range = 0.5f;

    void Start() 
    {
        originalPos = transform.position;
    }

    public void Drag(bool _move) 
    {
        move = _move;
    }

    public void FixedUpdate() 
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        
        float distance = (mousePosition - originalPos).magnitude;

        if (move) 
        {
            if (distance <= range)
            {
                /* Smooth movement */
                //Vector2 offset = mousePosition - (Vector2)transform.position;
                //if (offset.magnitude > moveSpeed)
                //{
                //offset.Normalize();
                //offset *= moveSpeed;
                //}
                //transform.position += (Vector3)offset;
                
                transform.position = mousePosition;
            }
            else 
            {
                Vector2 step = mousePosition - originalPos;
                step.Normalize();
                step *= range;

                transform.position = originalPos + step;
            }
        }
        else 
        {
            transform.position = Vector2.Lerp(transform.position, originalPos, moveSpeed * 2);
        }

    }
}
