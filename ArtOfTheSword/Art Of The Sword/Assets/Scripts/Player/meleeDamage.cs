/// <summary>
/// Script that deals damage to any character that enters the trigger zone 
///    which is not on the same team as the owner.
/// In this case it should be attached to a weapon. 
/// The weapon can only damage enemies if the player has initiated an attack
///    This is done through the playerLookingScript.
/// Weapon will damage the first enemy it encounters, or it will deactivate
///    due to timeStamp
/// </summary>
using UnityEngine;
using System.Collections;

public class meleeDamage : MonoBehaviour {

	float damageAmount = 50;
	float animationLength;	//used for damaging time
	float attkStamp;	//used for attack animation

	GameObject curEnemy;

	EnemyBasic curEnemyScirpt;	//the current enemy's script

	bool canDamage;	//whether or not the weapon is currently damaging enemies
	bool enemyHit;	//enemy has been hit in a swing

	// Use this for initialization
	void Start () {
		canDamage = false;	//disable damage at game start
		enemyHit = false;	//no enemy has been hit

		//get animation
		//get animation length
	}

	// Update is called once per frame
	void Update () {

		//unit enters the collider and canDamage
		if (canDamage == true && enemyHit == true) 
		{
			print ("Attack is over");
			canDamage = false;
		}
		//timestamp check, if time is over stop damaging effect


	}

	//called whenever an enemy enters the sword trigger
	void OnTriggerEnter2D(Collider2D hitObj)
	{
		if(canDamage == true)
		{
			print ("Target has been hit, finding and calling enemy script");

			//sets the it object to the current enemy
			curEnemyScirpt = hitObj.GetComponent<EnemyBasic>();

			//call the damageHealth function
			curEnemyScirpt.damageUnit (damageAmount);
	
			//state that a target has been hit
			enemyHit = true;
		}
	}

	//script that damages an enemy unit, takes the enemy object
	public void damageEnemy(GameObject enemyObj)
	{
		//deactivate damage
		canDamage = false;
		print ("finding and calling enemy script");
		//find enemy script on enemy target
		curEnemyScirpt = enemyObj.GetComponent<EnemyBasic>();
		//call the damageHealth function
		curEnemyScirpt.damageUnit (damageAmount);
	}

	public void attack()
	{
		print ("damaging activated");
		//allow damaging effect
		canDamage = true;
		//set new enemy hit possible
		enemyHit = false;
		//set timeStamp
		//activate animation
	}
}
