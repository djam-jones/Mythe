using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour 
{

    private float MovementSpeed = 3f;
    public Joystick joystick;
    private Rigidbody2D _body;
    private bool _isJumping;
    private float _jumpSpeed = 2f;
    private uint _jumpForce = 350;

    void Start() 
    {
        _body = GetComponent<Rigidbody2D>();
        CameraFocus.SetFocusOn(this.gameObject);
    }

    void Update() 
    {
        Move();
    }

    void Move() 
    {
        float x;
        Vector2 velocity;

        x = joystick.GetOffsetX();
        velocity = _body.velocity;
        velocity.x = x * MovementSpeed;
        _body.velocity = velocity;
    }

    public void Jump() 
    {
        if (_isJumping) return;
        _isJumping = true;

        transform.rigidbody2D.AddForce(Vector2.up * _jumpSpeed * _jumpForce);
    }
    
    private void OnCollisionEnter2D(Collision2D hit) 
    {
        if (hit.transform.tag == "Ground") {
            _isJumping = false;
        }
    }

}
