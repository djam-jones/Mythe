﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

    // Boy Voesten

public class PlayerMovement : MonoBehaviour 
{

    private Rigidbody2D _body;
    private Animator _anim;
    private float _movementSpeed = 4f;
    private float _offsetX;
    private bool _facingLeft = false;
    private bool _isJumping;
    private float _jumpSpeed = 4f;
    [SerializeField] private uint _jumpForce = 450;
	[SerializeField] private AudioClip[] _audioList;
	[SerializeField] private AudioSource _audio;
    
    public bool moveByKeyboard;
    public bool moveByJoystick;

    void Awake() 
    {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("LayerHuman"), LayerMask.NameToLayer("LayerAlien"), true);
    }

    void Update() 
    {
        Movement();
    }

    void Movement() 
    {
        // Dev cheat - Enables disgustingly quick movement for keyboard.
        if (moveByKeyboard) 
        {
            float x = Input.GetAxis("Horizontal") * 10 * Time.deltaTime;
            float y = Input.GetAxis("Vertical") * 20 * Time.deltaTime;

            transform.Translate(new Vector2(x, y));
        }

        // Movement by Joystick, this is the actual movement.
        if (moveByJoystick) 
        {
            Vector2 velocity;

            velocity = _body.velocity;
            velocity.x = _offsetX * _movementSpeed;
            _body.velocity = velocity;

            // Animations & Flipping
            if (_body.velocity.x < 0) 
            {
                if (!_facingLeft) 
                { 
                    Flip();
                }
				_anim.Play("Run");
				_audio.clip = _audioList[0];
				if(_audio.isPlaying == false)
					_audio.Play();
            }
            else if (_body.velocity.x > 0) 
            {
                if (_facingLeft) 
                {
                    Flip();
                }
				_anim.Play("Run");
				_audio.clip = _audioList[0];
				if(_audio.isPlaying == false)
					_audio.Play();
            } 
            else if (!_isJumping) 
            {
                _anim.Play("Idle");
            }
        }

    }

    // Flip object by inverting it's scale X
    private void Flip() 
    {
        _facingLeft = !_facingLeft;

        Vector3 objScale;
        objScale = transform.localScale;
        objScale.x *= -1;
        transform.localScale = objScale;
    }


    // Jumping related

    public void Jump() 
    {
        if (_isJumping) return;
        _isJumping = true;

        _anim.Play("Jump");
		_audio.clip = _audioList[1];
		if(_audio.isPlaying == false)
			_audio.Play();
        transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _jumpSpeed * _jumpForce);
    }

    private void Landed() 
    {
        _isJumping = false;
    }


    // Collisions

    private void OnCollisionEnter2D(Collision2D hit) 
    {
        if (hit.transform.tag == AllTagsConstants.groundTag 
        || hit.transform.tag == AllTagsConstants.objectTag 
        || hit.transform.tag == AllTagsConstants.alienTag 
        || hit.transform.tag == AllTagsConstants.platformTag
        || hit.transform.tag == AllTagsConstants.trapDoorTag) 
        {
            if (_isJumping) 
            {
                _anim.Play("Land");
				_audio.clip = _audioList[2];
                if (_audio.isPlaying == false) 
                {
                    _audio.Play();
                }
                Invoke("Landed", .5f);
            }
            else 
            {
                _isJumping = false;
            }
        }

		if(hit.transform.tag == AllTagsConstants.platformTag)
		{
			transform.SetParent(hit.transform);
		}
    }
	
	void OnCollisionExit2D(Collision2D hit)
	{
		if(hit.transform.tag == AllTagsConstants.platformTag)
		{
			transform.SetParent(null);
		}
	}


    // Getters & Setters

    public float offsetX 
    {
        set 
        {
            _offsetX = value;
        }
    }

}
