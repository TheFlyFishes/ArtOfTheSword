/// <summary>
/// This script holds all the information about the player's
/// earned exp and gold throughout the current level. It will
/// also add the earnings to the playerPrefs when the level ends
/// </summary>
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class playerCounters : MonoBehaviour {

	//values displayed in-level
	public static int earnedEXP;
	public static int earnedGold;
	//values in playerPrefs
	public static int savedEXP;
	public static int savedGold;
	public static int totalEXP;
	public static int totalGold;
	//text displays for counters
	public Text expDisplay;
	public Text goldDisplay;
	
	// Use this for initialization
	void Start () {
		setupCounters ();

	}
	
	// Update is called once per frame
	void Update () {
	
		//update displays
		expDisplay.text = earnedEXP.ToString();
		goldDisplay.text = earnedGold.ToString();
	}

	//sets up the level's counters
	public void setupCounters ()
	{
		//reset the earned amounts
		earnedEXP = 0;
		earnedGold = 0;
		savedEXP = 0;
		savedGold = 0;
		//get current playerPrefs amounts
		savedEXP = PlayerPrefs.GetInt ("curPlayerEXP");
		savedGold = PlayerPrefs.GetInt ("curPlayerGold");
		totalEXP = PlayerPrefs.GetInt ("totPlayerEXP");
		totalGold = PlayerPrefs.GetInt ("totPlayerGold");
	}

	//saves the player's earnings to playerPrefs (called when game ends)
	public static void saveEarnings ()
	{
		//calculate new values
		savedEXP = savedEXP + earnedEXP;
		savedGold = savedGold + earnedGold;
		totalEXP += earnedEXP;
		totalGold += earnedGold;

		//print ("Calc's vals: exp " + savedEXP.ToString() + " expT " + totalEXP.ToString());
		//print ("gold " + savedGold.ToString() + " goldT " + totalGold.ToString());

		//write changes
		PlayerPrefs.SetInt ("totPlayerEXP", totalEXP);
		PlayerPrefs.SetInt ("totPlayerGold", totalGold);
		PlayerPrefs.SetInt ("curPlayerEXP", savedEXP);
		PlayerPrefs.SetInt ("curPlayerGold", savedGold);
		//save the changes
		PlayerPrefs.Save ();
	}

	//called by killed enemies to increase counters
	public static void addEarnings (int addEXP, int addGold)
	{
		earnedEXP = earnedEXP + addEXP;
		earnedGold = earnedGold + addGold;
	}
}
