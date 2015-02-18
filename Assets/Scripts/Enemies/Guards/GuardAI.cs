using UnityEngine;
using System.Collections;

public enum GuardStates
{
	patrolling,
	attacking,
	searching
}

public class GuardAI : MonoBehaviour 
{
	public GuardStates states;

	private GameObject _target;
	private bool _hasSpotted;
	private float _speed = 2.5f;
	private bool facingRight = false;
	private float _counter = 5;

	public Transform endOfSight;
	public GameObject alertedSprite;
	public AudioClip[] guardSounds;
	private float _scale;

	void Awake()
	{
		_target = GameObject.FindWithTag("Human");
	}

	void Start()
	{
		StartCoroutine(PatrolState());
		_scale = transform.localScale.x;
	}

	void Update()
	{
		Raycasting();
		Behaviours();
		SetState();
	}

	void Raycasting()
	{
//		RaycastHit2D hit = Physics2D.Raycast(transform.position, endOfSight.position - transform.position);
//		if(hit)
//		{
//			if (hit.transform.tag == "Human")
//			{
//				_hasSpotted = true;
//				print("Target Seen! " + _hasSpotted);
//			}
//			else if(hit.transform.tag != "Human")
//			{
//				_hasSpotted = false;
//				print("Target Seen! " + _hasSpotted);
//			}
//		}

		Debug.DrawLine(transform.position, endOfSight.position, Color.green);
		_hasSpotted = Physics2D.Linecast(transform.position, endOfSight.position, 1 << LayerMask.NameToLayer("Player"));
	}

	void SetState()
	{
		if(states == GuardStates.patrolling)
		{
			StartCoroutine(PatrolState());
		}
		else if(states == GuardStates.attacking)
		{
			//Attack the Player
			Attack();
		}
		else if(states == GuardStates.searching)
		{
			//Search for Player
		}
	}

	public IEnumerator PatrolState()
	{
		_counter -= Time.deltaTime;

		if(_counter <= 0)
		{
			_counter = 5;
		}

		yield return new WaitForSeconds(_counter);
		Flip();
	}

	void Flip()
	{
		facingRight = !facingRight;

		Vector2 scale = transform.localScale;

		scale.x *= -1;
		transform.localScale = scale;
	}

	void Behaviours()
	{
		if(_hasSpotted == true)
		{
			Debug.Log("Spotted");

			audio.clip = guardSounds[0];
			audio.Play();
			alertedSprite.SetActive(true);

			//Set the Guards State to Attack.
			states = GuardStates.attacking;
		}
		else if(_hasSpotted == false)
		{
			alertedSprite.SetActive(false);
			states = GuardStates.patrolling;
		}
	}

	void Attack()
	{
		//Stops the Coroutine if the Enemy spots the Player.
		StopCoroutine(PatrolState());
		
		float step = _speed * Time.deltaTime;
		transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, step);

		float distance = Vector2.Distance(transform.position, _target.transform.position);
		if(distance < 3.5f)
		{
			//Fire gun
			Debug.Log ("In Range");

			audio.clip = guardSounds[1];
			audio.Play();
		}
	}
}
