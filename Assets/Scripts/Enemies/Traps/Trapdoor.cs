using UnityEngine;
using System.Collections;

//Djamali

public class Trapdoor : MonoBehaviour 
{
	private Animator _doorAnimator;

	void Awake()
	{
		_doorAnimator = GetComponent<Animator>();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.transform.tag == "Human")
		{
			_doorAnimator.SetTrigger("DoorClose");
			//Play Door Audio
		}
		else if(other.transform.tag == "Alien")
		{
			_doorAnimator.SetTrigger("DoorClose");
			//Play Door Audio
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.transform.tag == "Human" && other.transform.tag == "Alien")
		{
			_doorAnimator.SetTrigger("DoorOpen");
			//Play Door Audio
		}
	}

}
