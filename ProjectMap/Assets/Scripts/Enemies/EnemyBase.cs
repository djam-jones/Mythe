using UnityEngine;
using System.Collections;

public enum Enemy 
{
	basic,
	aerial,
	dive
}

public class EnemyBase : MonoBehaviour {

	//Set Health Variables
	protected		int maxHealth;
	private 		int _currentHealth;

	//Set Attacking Booleans
	public			bool hasAttack;
	public			bool attack;

	//Set Movement Variables
	public float speed = 10;

	//Set the Player Object
	public GameObject _player;

	public Enemy typeEnemy;

	void Start()
	{
		_currentHealth = maxHealth;

		_player = GameObject.FindGameObjectWithTag("Player");
		Debug.Log(_player.tag);
	}

	public void Update()
	{
		if(_currentHealth >= maxHealth)
		{
			_currentHealth = maxHealth;
		}

		//Option for Attacking
		if(hasAttack)
		{
			//Attack
		}
		else if(!hasAttack)
		{
			//
		}

		//Movement
		/*
		 * Go from Right to Left
		 * Stop at about 1/3 of the screen if the enemy has a shooting function
		 * and shoot at the Player
		 * If not stop in front of the Player and attack
		 * 
		 * Or if the player doesn't have an attack function at all.
		 * Stop in front of the Player and 'explode'.
		 */
	}

	public void SetHealth()
	{
		//Set Enemy Health for the types of enemies
		if(typeEnemy == Enemy.basic)
		{
			maxHealth = 50;
			hasAttack = false;
		}
		else if(typeEnemy == Enemy.aerial)
		{
			maxHealth = 75;
			hasAttack = true;
		}
		else if(typeEnemy == Enemy.dive)
		{
			maxHealth = 25;
			hasAttack = true;
		}

		Debug.Log ("Health: " + maxHealth + " on Type: " + typeEnemy);
	}

	public void ReceiveDamage(int amount)
	{
		//Subtract the Amount of Damage from the Health you currently have
		_currentHealth -= amount;

		if(_currentHealth <= 0)
		{
			Death();
		}
	}

	void Death()
	{
		Destroy(gameObject);
	}

}