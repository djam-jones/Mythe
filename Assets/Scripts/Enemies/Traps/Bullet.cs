using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	private float _travelSpeed = 25f;
	private float _destructionCounter = 3.5f;
	private Vector2 _shootDir;

	private GameObject _barrel;

	void Awake()
	{
		_barrel = GameObject.Find("Barrel");
		_shootDir = -_barrel.transform.up;
	}

	void Update()
	{
		BulletMovement();

		_destructionCounter -= Time.deltaTime;
		if(_destructionCounter <= 0)
		{
			Destroy(gameObject);
		}
	}

	public void BulletMovement()
	{
		transform.Translate(_shootDir * _travelSpeed * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.transform != null)
		{
			Destroy(this.gameObject);
		}
	}
}