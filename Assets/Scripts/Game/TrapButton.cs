using UnityEngine;
using System.Collections;

<<<<<<< HEAD
public class TrapButton : MonoBehaviour 
{
	private GameObject _trapDoor;

	void Awake()
	{
		_trapDoor = GameObject.FindGameObjectWithTag("Trapdoor");
=======
//Djamali

public class TrapButton : MonoBehaviour 
{
	private GameObject _trapDoor;

	void Awake()
	{
		_trapDoor = GameObject.Find("Trap Door");
>>>>>>> ea307b24d80a563fa9720516f69eccac59f18b2a
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.transform.tag != null)
		{
			print("Turning off Door.");

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
