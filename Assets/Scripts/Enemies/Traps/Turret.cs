using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Djamali

public class Turret : MonoBehaviour
{
	private GameObject _target;
	private bool _humanSpotted;

	private List<GameObject> _lineOfSight = new List<GameObject>();

	private float _minRotPoint = -90;
	private float _maxRotPoint = 90;

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
		
		float distance = Vector2.Distance(_target.transform.position, transform.position);
		
		if(inSight)
		{
			Debug.Log("hey " + inSight);
		}
	}

	IEnumerator RotateGun()
	{
		
		yield return null;
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