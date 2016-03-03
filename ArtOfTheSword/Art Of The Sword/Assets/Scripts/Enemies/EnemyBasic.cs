/// <summary>
/// Makes up the basic enemy.
/// </summary>
using UnityEngine;
using System.Collections;

//extends character, taking all public details
public class EnemyBasic : Character {

	float mHP = 100;
	int valEXP = 5;
	int valGold = 10;


	// Use this for initialization
	void Start () {

		setMHealth (mHP);
		curHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		//no HP, call death
		if (curHealth < 1) 
		{
			Death();
		}
	}

	//kills the unit
	public void Death()
	{
		print ("killed object");
		playerCounters.addEarnings (valEXP, valGold); //give rewards
		Destroy(this.gameObject) ;//destroy self
	}
}
