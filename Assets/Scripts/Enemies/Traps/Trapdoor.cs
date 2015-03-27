using UnityEngine;
using System.Collections;

//Djamali

public class Trapdoor : MonoBehaviour 
{
	private AudioSource 		_audioSource;
	private Animator			_anim;
	private PolygonCollider2D 	_trigger;
    
    [SerializeField] 
    private AudioClip[] _audioFragments;

	[HideInInspector]
	public bool isOpen = true;

	void Awake()
	{
		_audioSource = GetComponent<AudioSource>();
		_anim = GetComponent<Animator>();
		_trigger = GetComponent<PolygonCollider2D>();
	}

	public void OpenDoor()
	{
		_anim.SetTrigger("OpenDoor");

        // Play Open audio
        _audioSource.clip = _audioFragments[0];
        _audioSource.Play();
	}

	public void CloseDoor()
	{
		_anim.SetTrigger("CloseDoor");

        // Play Close audio
        _audioSource.clip = _audioFragments[1];
        _audioSource.Play();
	}
}