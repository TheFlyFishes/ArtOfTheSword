/// <summary>
/// Gets all player stats as written in playerPrefs
/// and displays them on the stats page.
/// </summary>
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class GUI_StatsDisplay : MonoBehaviour {

	//text displays for counters
	public Text totEXPDisplay;
	public Text totGoldDisplay;

	// Use this for initialization
	void Update () 
	{
		getValues ();
	}

	void getValues () {
		totEXPDisplay.text = PlayerPrefs.GetInt ("totPlayerEXP").ToString();
		totGoldDisplay.text = PlayerPrefs.GetInt ("totPlayerGold").ToString();
	}
}
