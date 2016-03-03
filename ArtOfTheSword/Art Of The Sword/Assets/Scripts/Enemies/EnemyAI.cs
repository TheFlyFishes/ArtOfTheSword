/// <summary>
/// Extremely basic enemy AI, just follows the player's
/// character around the map. Should only be used as a
/// template for more advanced AI (or maybe for zombies).
/// </summary>

using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public Transform target;

	public float moveSpeed;	//how fast the unit can move
	public float rotationSpeed;	//how fast the unit can rotate
	public float attkDamage = 20f;	//damage dealt by a single attack
	public float attkSpeed = 1.2f;	//delay between attacks


	public Transform myTransform;	//unit self

	public bool canAttack;	//whether or not an attack can be made



	public void Awake()
	{
		huntSetup();
	}
	
	
	void Start ()
	{
	}
	
	public void Update ()
	{
		//if the unit can attack
		if (canAttack == true) {
			huntPlayer ();	//chase the target
		}
	}

	public void huntSetup()
	{
		canAttack = true;
		myTransform = this.transform;
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	public void huntPlayer ()
	{
		// Get a direction vector from us to the target
		Vector3 dir = target.position - myTransform.position;
		
		// Normalize it so that it's a unit direction vector
		dir.Normalize();
		
		// Move ourselves in that direction
		myTransform.position += dir * moveSpeed * Time.deltaTime;
	}

	//called to refresh a unit's attack
	public IEnumerator attackWait ()
	{
		yield return new WaitForSeconds(attkSpeed);
		canAttack = true;
	}
}