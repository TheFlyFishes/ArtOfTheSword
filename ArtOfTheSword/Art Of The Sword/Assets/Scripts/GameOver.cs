/// <summary>
/// Handles the victory and loss clean up phase of the level.
/// This is called from a variety of places (EnemyManager, playerCharacter, etc.)
/// </summary>
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {

	public static GameObject vicMenu;
	public GameObject hold;

	void Awake () 
	{
		vicMenu = hold;
	}

	//called when the player wins the map
	public static void egVictory ()
	{

		//save all earnings from the map
		playerCounters.saveEarnings();
		//display victory menu
		vicMenu.SetActive(true);
	}
}
