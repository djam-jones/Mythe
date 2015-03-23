using UnityEngine;
using System.Collections;

    // Boy Voesten

public class PlayerMovement : MonoBehaviour 
{

    private bool _isJumping;
    private float _jumpSpeed = 2f;
    private uint _jumpForce = 450;
    private Rigidbody2D _body;
    private float _movementSpeed = 3f;
    private float _offsetX;

    public bool moveByKeyboard;
    public bool moveByJoystick;
	private GameObject _respawnPoint;

    public float offsetX 
    {
        set 
        {
            _offsetX = value;
        }
    }

    void Awake() 
    {
        _body = GetComponent<Rigidbody2D>();
		_respawnPoint = GameObject.FindGameObjectWithTag(AllTagsConstants.respawnTag);
    }

    void Update() 
    {
        Movement();
    }

    void Movement() 
    {
        // So that we can easilly turn it on and off in the inspector
        if (moveByKeyboard) 
        {
            float x = Input.GetAxis("Horizontal") * 10 * Time.deltaTime;
            float y = Input.GetAxis("Vertical") * 20 * Time.deltaTime;

            transform.Translate(new Vector2(x, y));
        }

        if (moveByJoystick) 
        {
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

        transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _jumpSpeed * _jumpForce);
    }

    // Collision

    private void OnCollisionEnter2D(Collision2D hit) 
    {
		if (hit.transform.tag == AllTagsConstants.groundTag) {
            _isJumping = false;
        }

		if(hit.transform.tag == AllTagsConstants.platformTag)
		{
			transform.SetParent(hit.transform);
		}

		if(hit.transform.tag == AllTagsConstants.trapTag)
		{
			//Return to Respawn Point if you hit a trap
			transform.position = _respawnPoint.transform.position;
		}
    }
	
	void OnCollisionExit2D(Collision2D hit)
	{
		if(hit.transform.tag == AllTagsConstants.platformTag)
		{
			transform.SetParent(null);
		}
	}

}
