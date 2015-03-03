using UnityEngine;
using System.Collections;

    // Boy Voesten

public class PlayerMovement : MonoBehaviour 
{

    private bool _isJumping;
    private float _jumpSpeed = 2f;
    private uint _jumpForce = 350;
    private Rigidbody2D _body;
    private float _movementSpeed = 3f;
    private float _offsetX;

    public bool moveByKeyboard;
    public bool moveByJoystick;
    public float offsetX {
        set {
            _offsetX = value;
        }
    }

    void Start() 
    {
        _body = GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        Movement();
    }

    void Movement() 
    {
        // So that we can easilly turn it on and off in the inspector
        if (moveByKeyboard) {
            float x = Input.GetAxis("Horizontal") * 10 * Time.deltaTime;
            float y = Input.GetAxis("Vertical") * 20 * Time.deltaTime;

            transform.Translate(new Vector2(x, y));
        }

        if (moveByJoystick) {
            Vector2 velocity;

            velocity = _body.velocity;
            velocity.x = _offsetX * _movementSpeed;
            _body.velocity = velocity;
        }
        
    }

    public void Jump() 
    {
        if (_isJumping) return;
        _isJumping = true;

        transform.rigidbody2D.AddForce(Vector2.up * _jumpSpeed * _jumpForce);
    }
    
    private void OnCollisionEnter2D(Collision2D hit) 
    {
        // TODO: Replace string with a const
        if (hit.transform.tag == "Ground") {
            _isJumping = false;
        }

		if(hit.transform.tag == "MovingPlatform")
		{
			transform.SetParent(hit.transform);
		}
    }
	
	void OnCollisionExit2D(Collision2D hit)
	{
		if(hit.transform.tag == "MovingPlatform")
		{
			transform.SetParent(null);
		}
	}

}
