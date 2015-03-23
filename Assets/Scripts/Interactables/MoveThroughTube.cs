//written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class MoveThroughTube : MonoBehaviour 
{
	[SerializeField] private uint _duration = 1;
    [SerializeField] private Transform _destination;
    private PlayerTools _playerTools;

    void Start()
    {
        _playerTools = GameObject.FindGameObjectWithTag(AllTagsConstants.gameManagerTag).GetComponentInChildren<PlayerTools>();
    }

	void OnTriggerEnter2D (Collider2D Other)
	{
		if (Other.tag == AllTagsConstants.alienTag)
		{
			StartCoroutine(GoThrough(Other.gameObject));
		}
	}

	IEnumerator GoThrough (GameObject alien)
	{
        _playerTools.ThroughTube(alien, true, _destination);

		yield return new WaitForSeconds(_duration);

        _playerTools.ThroughTube(alien, false, _destination);
    }

}
