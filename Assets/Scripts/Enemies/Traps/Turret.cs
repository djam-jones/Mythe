using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Djamali

public class Turret : MonoBehaviour
{
	private GameObject _target;
	private bool _humanSpotted;

	private Vector3 _startRotation = new Vector3(0f, 0f, -90f);
	private Vector3 _rotationAngle = new Vector3(0f, 0f, 90f);
	private float _rotationSpeed = 0.125f;
	
	private List<GameObject> _lineOfSight = new List<GameObject>();
//
//	/// <summary>
//	/// The Array of Bullets to fire when the Shoot function stars.
//	/// </summary>
//	public GameObject bullet;

	/// <summary>
	/// The length of time it will take to destroy the bullet. After which the bullet will be reset and pooled if needed.
	/// </summary>
	public float bulletDestructionTime = 1f;

	/// <summary>
	/// The bullet's Speed.
	/// </summary>
	public float bulletSpeed = 25f;

	/// <summary>
	/// Should the bullet be added to the bullets pool after completion
	/// </summary>
	[HideInInspector]
	public bool poolAfterComplete = true;

	void Awake()
	{
		_target = GameObject.FindGameObjectWithTag(AllTagsConstants.humanTag);
	}

	void Update()
	{
		StartCoroutine("RotateGun");
		SpotObject(false);
		
		if(_humanSpotted)
		{
			StopCoroutine("RotateGun");
			Shoot();
		}
	}

	void SpotObject(bool inSight)
	{
		inSight = _humanSpotted;
		
		float dist = 999999.99f;
		GameObject closestObject = null;
		foreach(GameObject objectInList in _lineOfSight)
		{
			float distance = Vector2.Distance( objectInList.transform.position, transform.position);
			if(dist > distance)
			{
				dist = distance;
				closestObject = objectInList;
			}
		}

		if(_lineOfSight.Contains(_target) && closestObject == _target)
		{
			inSight = true;
		}
	}

	public IEnumerator DisableGun(float _disableTime)
	{
		StopCoroutine("RotateGun");
		yield return new WaitForSeconds(_disableTime);
		StartCoroutine("RotateGun");
	}

	IEnumerator RotateGun()
	{
		float t = Mathf.PingPong(Time.time * _rotationSpeed, 1);
		transform.eulerAngles = Vector3.Lerp(_startRotation, _rotationAngle, t);

		yield break;
	}

	/// <summary>
	/// Will Shoot the gun
	/// </summary>
	public virtual void Shoot()
	{
		ObjectPool.instance.GetObjectForType("BulletObject", false);
		//bullet.transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime, Space.Self);

//		foreach(GameObject bullet in bullets)
//		{
//			bullet.transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime, Space.Self);
//		}

		StartCoroutine(WaitForCompletion());
	}

	/// <summary>
	/// Will Reset the gun
	/// </summary>
	public virtual void ResetGun()
	{
		if(poolAfterComplete)
		{
//			ObjectPool.instance.PoolObject();
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public IEnumerator WaitForCompletion()
	{
		//Wait for the shooting to complete itself
		yield return new WaitForSeconds(bulletDestructionTime);
		//Reset the Shooting
		ResetGun();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.transform.tag != null)
		{
			//Add GameObject to the sight List
			_lineOfSight.Add(other.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.transform.tag != null)
		{
			//Remove GameObject from the sight List
			_lineOfSight.Remove(other.gameObject);
		}
	}
}