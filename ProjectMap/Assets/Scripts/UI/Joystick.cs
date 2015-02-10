using UnityEngine;
using System.Collections;

public class Joystick : MonoBehaviour {

    private Vector2 mousePosition;
    private Vector2 originalPos;
    public float moveSpeed = 0.1f;
    private bool move;

    void Start() {
        originalPos = transform.position;
    }

    public void Drag(bool _move) {
        move = _move;
    }

    public void Update() {
        if (move) {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        } else {
            transform.position = Vector2.Lerp(transform.position, originalPos, moveSpeed * 2);
        }
    }
}
