using UnityEngine;
using System.Collections;

//Djamali

public class TrapButton : MonoBehaviour 
{
	private GameObject _trapDoor;
	private GameObject movingPlatform;

	void Awake()
	{
		_trapDoor = GameObject.FindGameObjectWithTag(AllTagsScript.trapDoorTag);
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.transform.tag != null)
		{
			//Play The DoorOpen Animation and lock it.
			if(_trapDoor != null)
			{
				_trapDoor.GetComponent<Animator>().SetTrigger("DoorOpen");
				//Play Trapdoor Audio.
			}
//			else if(movingPlatform != null)
//			{
//
//			}

			//Turn off the Trapdoor.
			StartCoroutine(DisableTrap());
		}
	}

	IEnumerator DisableTrap()
	{
		yield return new WaitForSeconds(0.5f);
		if(_trapDoor != null)
			_trapDoor.SetActive(false);
//
//		else if(movingPlatform != null)
//			movingPlatform.SetActive(false);
	}

}
