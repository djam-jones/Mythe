using UnityEngine;
using System.Collections;

//Djamali

public class Trapdoor : MonoBehaviour 
{
	private Animator _doorAnimator;
	private AudioSource _doorAudio;
	private AudioClip[] _doorAudioFragments;

	void Awake()
	{
		_doorAnimator = GetComponent<Animator>();
		_doorAudio = GetComponent<AudioSource>();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.transform.tag == AllTagsScript.humanTag || other.transform.tag == AllTagsScript.alienTag)
		{
			Close();
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.transform.tag == AllTagsScript.humanTag && other.transform.tag == AllTagsScript.alienTag)
		{
			Open();
		}
	}

	public void Open()
	{
		_doorAnimator.SetTrigger("DoorOpen");
		//Play Door Audio
	}

	public void Close()
	{
		_doorAnimator.SetTrigger("DoorClose");
		//Play Door Audio
	}
}