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
	private float _rotationSpeed = 0.12f;
	private bool _rotatable = true;
	
	private List<GameObject> _lineOfSight = new List<GameObject>();

//	public Bullet[] bullets;
//	private int _bulletCache = 0;
//	private int _activeBullet = 0;
	public GameObject bullet;
	public GameObject gunBarrel;
	private float _bulletDestructionTime = 5f;
	private float _bulletCoolDown;
	private float _defaultCoolDownTime = 2f;

	void Awake()
	{
		_bulletCoolDown = _defaultCoolDownTime;
		_target = GameObject.FindGameObjectWithTag(AllTagsConstants.humanTag);
//		_bulletCache = bullets.Length;
	}
	
	void Update()
	{
		StartCoroutine("RotateGun");
		SpotObject();

		if(_humanSpotted)
		{
			StopCoroutine("RotateGun");
			Shoot();
		}
	}
	
	void SpotObject()
	{
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
			_humanSpotted = true;
		}
	}
	
	public IEnumerator DisableGun(float _disableTime)
	{
		_rotatable = false;
		yield return new WaitForSeconds(_disableTime);
		_rotatable = true;
	}
	
	IEnumerator RotateGun()
	{
		if(_rotatable)
		{
			float t = Mathf.PingPong(Time.time * _rotationSpeed, 1);
			transform.eulerAngles = Vector3.Lerp(_startRotation, _rotationAngle, t);
		}
		
		yield break;
	}

	public void Shoot()
	{
		_bulletCoolDown -= Time.deltaTime;
		if(_bulletCoolDown <= 0)
		{
			Instantiate(bullet, gunBarrel.transform.position, Quaternion.identity);
			_bulletCoolDown = _defaultCoolDownTime;
		}

//		bullets[_activeBullet].Fire();
//		bullets[_activeBullet].gameObject.transform.Translate(_bulletShootDir);
//		yield return new WaitForSeconds(_bulletDestructionTime);
//		Destroy(bullets[_activeBullet].gameObject);
//
//		_activeBullet += 1;
//
//		if(_activeBullet > _bulletCache -1)
//		{
//			_activeBullet = 0;
//		}
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