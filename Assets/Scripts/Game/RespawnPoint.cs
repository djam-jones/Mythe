using UnityEngine;
using System.Collections;

public class RespawnPoint : MonoBehaviour 
{
	private PlayerRespawn _playerRespawn;
	
	void OnTriggerEnter2D(Collider2D Col)
	{
		if(Col.transform.tag == AllTagsConstants.alienTag || Col.transform.tag == AllTagsConstants.humanTag)
		{
			_playerRespawn = Col.GetComponent<PlayerRespawn>();
			_playerRespawn._respawnPoint = gameObject;
		}
	}
}
