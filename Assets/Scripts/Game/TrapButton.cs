using UnityEngine;
using System.Collections;

//Djamali

public class TrapButton : MonoBehaviour 
{
	public GameObject trapDoor;
	public GameObject movingPlatform;
	public GameObject turret;
	private MovingPlatform _movingPlatformScript;

	void Awake()
	{
		//trapDoor = GameObject.FindGameObjectWithTag(AllTagsScript.trapDoorTag);
		_movingPlatformScript = movingPlatform.GetComponent<MovingPlatform>();
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.transform.tag != null)
		{
			//Play The DoorOpen Animation and lock it.
			if(trapDoor != null)
			{
				//trapDoor.GetComponent<Trapdoor>().Open();
				trapDoor.GetComponent<Animator>().SetTrigger("DoorOpen");
				//Play Trapdoor Audio.
			}

			else if(movingPlatform != null)
			{
				if(_movingPlatformScript != null)
				{
					StopCoroutine(_movingPlatformScript.Move());
				}
			}
			else if(turret != null)
			{
				//Stop The Turret.
			}

			//Turn off the Trapdoor.
			StartCoroutine(DisableTrap());
		}
	}

	IEnumerator DisableTrap()
	{
		yield return new WaitForSeconds(0.5f);
		if(trapDoor != null)
			trapDoor.SetActive(false);
	}

}
