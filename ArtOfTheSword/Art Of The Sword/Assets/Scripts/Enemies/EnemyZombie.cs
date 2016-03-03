/// <summary>
/// Contains the working of the enemy unit 'zombie,'
/// which is intended to be a slow, low damaging unit
/// that appears in large quantities.
/// </summary>
using UnityEngine;
using System.Collections;

//takes basic AI package
public class EnemyZombie : EnemyAI {


	//generic zombie attack
	public void zombieSwipe()
	{
		//play animation
		//deal damage to anything inside of trigger zone
		StartCoroutine (attackWait());	//start attack refresh period

	}
}
