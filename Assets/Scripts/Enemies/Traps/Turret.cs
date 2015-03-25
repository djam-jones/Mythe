using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Djamali

public class Turret : MonoBehaviour
{
	private GameObject _target;
	private bool _humanSpotted;

	private Vector3 _startRotation = new Vector3(0f, 0f, -90f);
	private Vector3 _rotationAngle = new Vector3(0f, 0f, 90f);
	private float _rotationSpeed = 0.125f;
	
	private List<GameObject> _lineOfSight = new List<GameObject>();
	public GameObject gunBarrel;

	void Awake()
	{
		_target = GameObject.FindGameObjectWithTag(AllTagsConstants.humanTag);
	}

	void Update()
	{
		StartCoroutine(RotateGun());
		SpotObject(false);
	}

	void SpotObject(bool inSight)
	{
		inSight = _humanSpotted;
		
		float dist = 999999.99f;
		GameObject closestObject = null;
		foreach(GameObject objectInList in _lineOfSight)
		{
			float distance = Vector2.Distance( objectInList.transform.position, transform.position);
			if(dist > distance)
			{
				dist = distance;
				closestObject = objectInList;
				//Debug.Log("Closest object: " + closestObject + "\n" + "Distance: " + distance);
			}
		}

		if(_lineOfSight.Contains(_target) && closestObject == _target)
		{
			inSight = true;
		}

		if(inSight)
		{
			StopCoroutine(RotateGun());
			//Debug.Log("hey I'm " + inSight + " and this guy's a bitch!");
			Shoot();
		}
	}

	IEnumerator RotateGun()
	{
		float t = Mathf.PingPong(Time.time * _rotationSpeed, 1);
		transform.eulerAngles = Vector3.Lerp(_startRotation, _rotationAngle, t);

		yield return null;
	}

	void Shoot()
	{
		Debug.Log ("Release the keks!");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.transform.tag != null)
		{
			//Add GameObject to the sight List
			_lineOfSight.Add(other.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.transform.tag != null)
		{
			//Remove GameObject from the sight List
			_lineOfSight.Remove(other.gameObject);
		}
	}
}