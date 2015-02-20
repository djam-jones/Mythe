using UnityEngine;
using System.Collections;

public class EnemyDive : EnemyBase {

	void Start()
	{
		//Set the type of enemy.
		typeEnemy = Enemy.dive;
		SetHealth();

		_player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		//Run the Update function of the base class, before this update functions
		base.Update();

		if(Vector3.Distance(transform.position, _player.transform.position) < 10)
		{
			float step = speed * Time.deltaTime;

			Debug.DrawLine(transform.position, _player.transform.position);

			transform.LookAt(_player.transform.position);
			transform.Rotate(new Vector2(0, 90), Space.Self);
			transform.rotation = Quaternion.Slerp(transform.rotation, _player.transform.rotation, step);
			transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, step);
		}
	}
}
