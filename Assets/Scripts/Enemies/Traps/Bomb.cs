using UnityEngine;
using System.Collections;

//Djamali

public class Bomb : MonoBehaviour 
{

	//Variables Here

	void OnCollisionEnter2D(Collision2D hit)
	{
		if(hit.relativeVelocity.magnitude >= 7.5f && hit.transform.tag == AllTagsConstants.guardTag)
		{
			Debug.Log("Explode");

			//Explosion Stuff
		}
	}

}
