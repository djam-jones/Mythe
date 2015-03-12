using UnityEngine;
using System.Collections;

//Djamali

public class Turret : MonoBehaviour
{
	private GameObject _target;
	private bool _humanSpotted;

	void Awake()
	{
		_target = GameObject.FindGameObjectWithTag(AllTagsScript.humanTag);
	}

	void Update()
	{
		StartCoroutine("RotateGun", false);
	}

	IEnumerator RotateGun(bool inSight)
	{
		inSight = _humanSpotted;

		float distance = Vector2.Distance(_target.transform.position, transform.position);

		if(distance < 2 && inSight)
		{
			Debug.Log("hey " + inSight);
		}

		yield return inSight;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.transform.tag == AllTagsScript.humanTag || other.transform.tag == AllTagsScript.alienTag)
		{
			_humanSpotted = true;
		}
	}

}