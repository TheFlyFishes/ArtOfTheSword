/// <summary>
/// This script handles the creation of a new game and the process of
/// resetting all player counters. It is called everytime the 'New Game'
/// button is clicked in the main menu.
/// </summary>

using UnityEngine;
using System.Collections;

public class MM_NewGame : MonoBehaviour {

	public void ResetCounters ()
	{
		//all player values
		PlayerPrefs.SetInt ("totPlayerEXP", 0);
		PlayerPrefs.SetInt ("totPlayerGold", 0);
		PlayerPrefs.SetInt ("curPlayerEXP", 0);
		PlayerPrefs.SetInt ("curPlayerGold", 0);

		//print ("Reseting playerPrefs");

		//resets monster vars
		PlayerPrefs.SetInt ("zombiesModifierValue", 1);

		PlayerPrefs.Save ();
	}
}
