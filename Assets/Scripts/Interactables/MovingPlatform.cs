using UnityEngine;
using System.Collections;

//Djamali

public class MovingPlatform : MonoBehaviour 
{
	//A platform that will move from left to right, diagonal or up to down

	private Transform _target;
	private int _waypointIndex;
	public Transform[] waypoints;
	public float platformSpeed = 1.2f;
	[SerializeField] private float _waitTime = 0.2f;
    private bool _stopped = false;

	void Start()
	{
		//Set the Start value of _waypointIndex.
		_waypointIndex = 0;
		//Set the Start value for the Target.
		_target = waypoints[_waypointIndex];
	}

	void Update()
	{
        if (_stopped) return;

        Movement();
	}

    void Movement() 
    {
        //Move this Platform to one of the set target.
        transform.position = Vector2.MoveTowards(transform.position, _target.position, platformSpeed * Time.deltaTime);

		if (waypoints.Length != null)
		{
			if(transform.position == _target.position)
			{
				_waypointIndex += 1;
                StartCoroutine(SetNewTarget());
			}
			if(_waypointIndex >= waypoints.Length)
			{
				_waypointIndex = 0;
			}
		}

    }

	IEnumerator SetNewTarget()
	{
		yield return new WaitForSeconds(_waitTime);
		_target = waypoints[_waypointIndex];
	}
    
    public bool stopped 
    {
        set 
        {
            _stopped = value;
        }
    }
}