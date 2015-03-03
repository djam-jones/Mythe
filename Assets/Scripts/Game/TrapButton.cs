using UnityEngine;
using System.Collections;

//Djamali

public class TrapButton : MonoBehaviour 
{
	private GameObject _trapDoor;

	void Awake()
	{
		_trapDoor = GameObject.Find("Trap Door");
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.transform.tag != null)
		{
			//Play The DoorOpen Animation and lock it.
			_trapDoor.GetComponent<Animator>().SetTrigger("DoorOpen");
			//Play Trapdoor Audio.

			//Turn off the Trapdoor.
			StartCoroutine(DisableTrap());
		}
	}

	IEnumerator DisableTrap()
	{
		yield return new WaitForSeconds(0.5f);
		_trapDoor.SetActive(false);
	}

}
