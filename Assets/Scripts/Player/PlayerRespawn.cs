using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour 
{
	[SerializeField]private GameObject _respawnPoint;

	private void OnCollisionEnter2D(Collision2D Col)
	{
		if(Col.transform.tag == AllTagsConstants.trapTag)
		{
			transform.position = _respawnPoint.transform.position;
		}
	}

	private void OnTriggerEnter2d(Collider2D Col)
	{
		if(Col.transform.tag == AllTagsConstants.respawnTag)
		{
			_respawnPoint.transform.position = Col.transform.position;
		}
	}
}
