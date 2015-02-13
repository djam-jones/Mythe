using UnityEngine;
using System.Collections;

public class LaserTrap : MonoBehaviour {

	public GameObject laserBeam;

	void Start()
	{
		laserBeam.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.transform.tag == "Player")
		{
			laserBeam.SetActive(true);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		laserBeam.SetActive(false);
	}
}
