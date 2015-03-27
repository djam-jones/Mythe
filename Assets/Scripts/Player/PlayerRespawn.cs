using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour 
{
	public GameObject _respawnPoint;
	[SerializeField]private AudioClip _deathSound;
	[SerializeField]private AudioSource _audio;

	void OnCollisionEnter2D(Collision2D Col)
	{
		if(Col.transform.tag == AllTagsConstants.trapTag)
		{
			transform.position = _respawnPoint.transform.position;
			_audio.clip = _deathSound;
			_audio.PlayOneShot(_deathSound, 1.0f);
		}
	}
}
