using UnityEngine;
using System.Collections;

public class EnemyBasic : EnemyBase {

	void Start()
	{
		//Set the type of enemy.
		typeEnemy = Enemy.basic;
		SetHealth();
	}

	void Update()
	{
		//Run the Update function of the base class, before this update functions
		base.Update();
	}

}