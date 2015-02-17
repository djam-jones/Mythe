using UnityEngine;
using System.Collections;

public class TrapButton : MonoBehaviour {

	public GameObject trap;
	
	void OnColliderEnter2D(Collider2D col)
	{
		if(col.transform.tag == "Alien")
		{
			//Turn off the Trap
		}
	}

}
