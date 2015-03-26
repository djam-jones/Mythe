using UnityEngine;
using System.Collections;

//Djamali

public class Trapdoor : MonoBehaviour 
{
	private AudioSource 		_doorAudio;
	private AudioClip[] 		_doorAudioFragments;
	private Animator			_doorAnimator;
	private PolygonCollider2D 	_doorTrigger;

	[HideInInspector]
	public bool isOpen = true;

	private float _openingSpeed;
	private Vector2 _doorPos;
	private Vector2 _openPos = new Vector2(0, 3f);
	private Vector2 _closedPos = new Vector2(0, 0);

	void Awake()
	{
		_openingSpeed = 2f;
		_doorPos = transform.position;
		_doorAudio = GetComponent<AudioSource>();
		_doorAnimator = GetComponent<Animator>();
		_doorTrigger = GetComponent<PolygonCollider2D>();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.transform.tag == AllTagsConstants.humanTag || other.transform.tag == AllTagsConstants.alienTag)
		{
			CloseDoor();
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.transform.tag == AllTagsConstants.humanTag && other.transform.tag == AllTagsConstants.alienTag)
		{
			OpenDoor();
		}
	}

	public void OpenDoor()
	{
		//Vector2.Lerp(_doorPos, _openPos, _openingSpeed * Time.deltaTime);
		//isOpen = true;
		_doorAnimator.SetTrigger("OpenDoor");
		//_doorTrigger.enabled = false;

		//Play Door Audio
	}

	public void CloseDoor()
	{
		//Vector2.Lerp(_doorPos, _closedPos, _openingSpeed * Time.deltaTime);
		//isOpen = false;
		_doorAnimator.SetTrigger("CloseDoor");

		//Play Door Audio
	}
}