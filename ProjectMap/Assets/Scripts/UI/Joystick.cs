using UnityEngine;
using System.Collections;

public class Joystick : MonoBehaviour {

    private Vector2 mousePosition;
    private Vector2 originalPos;
    private float range = 0.3f;
    private float pivotToObj;
    private bool move;
    public float moveSpeed = 0.1f;

    void Start() {
        originalPos = transform.position;
    }

    public void Drag(bool _move) {
        move = _move;
    }

    public void FixedUpdate() {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        float distance = (mousePosition - originalPos).magnitude;
        float pivotToObj = ((Vector2)transform.position - originalPos).magnitude;
        float offsetX;

        if (move) {
            if (distance <= range) {
                /* Smooth movement */
                //Vector2 offset = mousePosition - (Vector2)transform.position;
                //if (offset.magnitude > moveSpeed)
                //{
                //offset.Normalize();
                //offset *= moveSpeed;
                //}
                //transform.position += (Vector3)offset;

                transform.position = mousePosition;
            } else {
                Vector2 step = mousePosition - originalPos;
                step.Normalize();
                step *= range;

                transform.position = originalPos + step;
            }
        } else {
            transform.position = Vector2.Lerp(transform.position, originalPos, moveSpeed * 2);
        }

        // This will prevent the values from going crazy when trying to return to it's original position
        if (pivotToObj > 0.1f) {
            pivotToObj = ((Vector2)transform.position - originalPos).magnitude;
            offsetX = (transform.position.x - originalPos.x) / range;
        } else {
            pivotToObj = 0;
            offsetX = 0;
        }

        Debug.Log(pivotToObj);
        Debug.Log(offsetX);
    }
}
