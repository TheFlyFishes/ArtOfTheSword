/// <summary>
/// This script ensures the player's character is always looking towards
/// the mouse pointer.
/// Also deals with attack calls and character attributes.
/// </summary>
using UnityEngine;
using System.Collections;

//extends character, taking all public details
public class playerCharacter : Character {

	private meleeDamage curWeaponScript;

	// Use this for initialization
	void Start () {
		curWeaponScript = weapon.GetComponent<meleeDamage>();//get weapon script instance
	}
	
	// Update is called once per frame
	void Update () {
			
		//character always looks toward the mouse
		Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		//left mouse button is down
		if(Input.GetMouseButtonDown(0))
		{
			MeleeAttack();
		}
	}

	public void MeleeAttack()
	{
		print ("attacking");
		//activate meleeDamage.cs
		curWeaponScript.attack ();
	}
}
