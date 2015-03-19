//written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class MoveThroughTube : MonoBehaviour 
{
	[SerializeField] private uint _duration = 1;
    [SerializeField] private Transform _destination;
    [SerializeField] private GameObject _alien;
    private SpriteRenderer _alienSpriteR;
    private BoxCollider2D _alienColl;
    private Rigidbody2D _alienRB;
    

	void OnTriggerEnter2D (Collider2D Other)
	{
		if (Other.tag == _alien.gameObject.tag)
		{
			StartCoroutine(GoThrough());
		}
	}

	IEnumerator GoThrough ()
	{
        _alienSpriteR = _alien.GetComponentInChildren<SpriteRenderer>();
        _alienColl = _alien.GetComponentInChildren<BoxCollider2D>();
        _alienRB = _alien.GetComponentInChildren<Rigidbody2D>();
        _alienSpriteR.enabled = false;
        _alienColl.enabled = false;
        _alienRB.isKinematic = true;
        _alien.transform.position = _destination.position;
		yield return new WaitForSeconds(_duration);
        _alien.transform.position = _destination.position;
        _alienSpriteR.enabled = true;
        _alienColl.enabled = true;
        _alienRB.isKinematic = false;
    }

}
