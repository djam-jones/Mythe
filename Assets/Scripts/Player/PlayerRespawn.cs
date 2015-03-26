using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour 
{
	public GameObject _respawnPoint;

	void OnCollisionEnter2D(Collision2D Col)
	{
		if(Col.transform.tag == AllTagsConstants.trapTag)
		{
			transform.position = _respawnPoint.transform.position;
		}
	}
}
