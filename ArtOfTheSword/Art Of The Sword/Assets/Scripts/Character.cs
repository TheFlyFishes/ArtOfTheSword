/// <summary>
/// Defines the basic attributes of all characters in the game,
/// this includes health, ect.
/// </summary>
using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public float curHealth;
	public float maxHealth = 100;
	public GameObject weapon;	//current weapon of character

	// Use this for initialization
	void Start () {
		maxHealth = curHealth;
	}
	
	// Update is called once per frame
	void Update () {

	}

	//damages the unit
	public void damageUnit(float amount)
	{
		print ("damaging enemy");
		curHealth = curHealth - amount;
		print (curHealth);
	}

//SETS AND GETS
	public void setMHealth(float newMHealth)
	{
		if (newMHealth > 0) {
			maxHealth = newMHealth;
		}
	}
}
