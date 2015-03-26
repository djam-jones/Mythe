using UnityEngine;
using System.Collections;

//Djamali

public class TrapButton : MonoBehaviour 
{
	public GameObject trap;
	private MovingPlatform _movingPlatformScript;
	private Turret _turretScript;
	private Trapdoor _trapDoorScript;

	private float _waitTime = 4f;

	void Awake()
	{
		_movingPlatformScript = trap.GetComponent<MovingPlatform>();
		_turretScript = trap.GetComponent<Turret>();
		_trapDoorScript = trap.GetComponent<Trapdoor>();

	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.transform.tag != null && col.tag != AllTagsConstants.groundTag)
		{
			if(trap.tag == AllTagsConstants.trapDoorTag && _trapDoorScript != null)
			{
				_trapDoorScript.OpenDoor();
				Debug.Log("Trapdoor");
			}
			else if(trap.tag == AllTagsConstants.platformTag && _movingPlatformScript != null)
			{
				_movingPlatformScript.StopMoving();
				Debug.Log("Platform");
			}
			else if(trap.tag == AllTagsConstants.turretTag && _turretScript != null)
			{
				_turretScript.DisableGun(_waitTime);
				Debug.Log("Turret");
			}
		}
	}
}
