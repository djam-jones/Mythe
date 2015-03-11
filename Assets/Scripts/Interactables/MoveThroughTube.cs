//written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class MoveThroughTube : MonoBehaviour 
{
	[SerializeField]
	private Transform _Destination;

	void OnTriggerEnter2D (Collider2D Other)
	{
		if (Other.tag == "Alien")
		{
			Other.transform.position = _Destination.position;
		}
	}
}
