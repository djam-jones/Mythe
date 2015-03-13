//written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class MoveThroughTube : MonoBehaviour 
{
	[SerializeField]
	private Transform _destination;
	[SerializeField]
	private GameObject _alien;

	void OnTriggerEnter2D (Collider2D Other)
	{
		if (Other.tag == "Alien")
		{
			StartCoroutine(GoThrough());
		}
	}
	IEnumerator GoThrough ()
	{
		_alien.SetActive (false);
		yield return new WaitForSeconds(1);
		_alien.transform.position = _destination.position;
		_alien.SetActive (true);
	}

}
