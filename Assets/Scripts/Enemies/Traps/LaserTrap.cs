using UnityEngine;
using System.Collections;

<<<<<<< HEAD
=======
//Djamali

>>>>>>> ea307b24d80a563fa9720516f69eccac59f18b2a
public class LaserTrap : MonoBehaviour 
{
	private float _laserTimer;
	public float interval = 2f;
	private bool _laserOn;

	public GameObject laserBeam;

	void Start()
	{
		//Set the default value of the Timer
		_laserTimer = interval;
	}

	void FixedUpdate()
	{
		_laserTimer -= Time.fixedDeltaTime;

		if(_laserTimer <= 0)
		{
			_laserOn = !_laserOn;

			laserBeam.SetActive(_laserOn);

			_laserTimer = interval;
		}
	}
}