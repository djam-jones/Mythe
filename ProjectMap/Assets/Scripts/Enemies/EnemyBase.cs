using UnityEngine;
using System.Collections;

public enum Enemy 
{
	basic,
	ground,
	aerial
}

public class EnemyBase : MonoBehaviour {

	public 			int maxHealth;
	private 		int _currentHealth;
	public			bool canAttack;

	public Enemy typeEnemy;

	void Awake()
	{
		_currentHealth = maxHealth;
	}

	void Update()
	{
		//Enemy Enum

		//Option for Attacking
		if(canAttack)
		{
			//Attack
		}
	}

	public void ReceiveDamage(int amount)
	{
		//Subtract the Amount of Damage from the Health you currently have
		_currentHealth -= amount;
	}

}