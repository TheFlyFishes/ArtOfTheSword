/// <summary>
/// Handles the display for how many enemies exist on the map and
/// what wave it is.
/// </summary>
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class enemyCounters : MonoBehaviour {

	public Text waveCounter_text;
	public Text enemiesLeftOnMap_text;
	public Text enemiesInSwarm_text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		counterUpdate ();
	}

	//handles counters regarding enemy amounts
	void counterUpdate ()
	{
		waveCounter_text.text = EnemyManager.WaveCounter.ToString();	//display wave counter through text
		enemiesLeftOnMap_text.text = EnemyManager.EnemiesLeftOnMap.ToString ();	//display enemies on map
		enemiesInSwarm_text.text = EnemyManager.EnemiesInSwarm.ToString ();	//display enemies remaining total
	}
}
