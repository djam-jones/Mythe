using UnityEngine;
using System.Collections;

//Djamali

public class TrapButton : MonoBehaviour 
{
	public GameObject trap;
	private MovingPlatform _movingPlatformScript;
	private Turret _turretScript;
	private Trapdoor _trapDoorScript;

	void Awake()
	{
		_movingPlatformScript = trap.GetComponent<MovingPlatform>();
		_turretScript = trap.GetComponent<Turret>();
		_trapDoorScript = trap.GetComponent<Trapdoor>();

	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.transform.tag != null)
		{
			if(trap.tag == AllTagsConstants.trapDoorTag && _trapDoorScript != null)
			{
				//Turn off Trap Door
				Debug.Log("Trapdoor");
			}
			else if(trap.tag == AllTagsConstants.platformTag && _movingPlatformScript != null)
			{
				//Turn off Platform
				Debug.Log("Platform");
			}
			else if(trap.tag == AllTagsConstants.turretTag && _turretScript != null)
			{
				//Turn off Turret
				Debug.Log("Turret");
			}
		}
	}
}
