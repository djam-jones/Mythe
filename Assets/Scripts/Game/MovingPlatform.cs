﻿using UnityEngine;
using System.Collections;

//Djamali

public class MovingPlatform : MonoBehaviour 
{
	//A platform that will move from left to right, diagonal or up to down

	private Transform _target;
	private int _waypointIndex;
	public Transform[] waypoints;

	void Start()
	{
		//Set the Start value of _waypointIndex.
		_waypointIndex = 0;
		//Set the Start value for the Target.
		_target = waypoints[_waypointIndex];
	}

	void Update()
	{
		StartCoroutine(Move());
	}

	public IEnumerator Move()
	{
		//Move this Platform to one of the set target.
		transform.position = Vector2.MoveTowards(this.transform.position, _target.position, 1.2f * Time.deltaTime);

		if(waypoints.Length != null)
		{
			if(transform.position == _target.position)
			{
				_waypointIndex += 1;
			}
			if(_waypointIndex >= waypoints.Length)
			{
				_waypointIndex = 0;
			}
		}

		yield return new WaitForSeconds(0.2f);
		_target = waypoints[_waypointIndex];
	}
}