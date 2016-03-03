/// <summary>
/// script deals with determining how many enemies to spawn, where, and of
/// what type.
/// </summary>
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public static int WaveCounter;
	public static int enemiesToSpawn;	//how many enemies are in the current wave
	public static int EnemiesLeftOnMap;	//total enemies on map
	public static int EnemiesInSwarm;	//enemies left in total
	public static int zombiesLeft;	//zombies

	public GameObject[] spawnPoints;	//possible enemy spawn points

	public float spawnDelay = 1.2f;
	private float temp;

	public GameObject zombie;	//holder for zombie unit
	public GameObject vicMenu;

	public bool canSpawn;	//whether or not an enemy can be spawned
	public bool isPlaying;	//whether the game is active or not

	// Use this for initialization
	void Start () {
		spawnWait();
		GameSetup ();	//set up the game
		canSpawn = true;	//allow spawning
	}
	
	// Update is called once per frame
	void Update () {

		//find remaining enemies alive
		EnemiesLeftOnMap = GameObject.FindGameObjectsWithTag ("Enemy").Length;

		//still enemies to spawn and past the timer
		if (enemiesToSpawn > 0 && canSpawn) {
			canSpawn = false;	//disable spawn
			spawnEnemies();	//call for enemy to be created
		}

		//spawn next wave if the current wave is over
		if (EnemiesLeftOnMap == 0 && EnemiesInSwarm != 0)
		{
			spawnWave();
		}
		//no enemies left on level or in reserve
		if (EnemiesLeftOnMap == 0 && EnemiesInSwarm == 0 && isPlaying)
		{
			isPlaying = false;
			 egVictory();//victory
		}
	}

	//Sets up the initial game variables
	void GameSetup()
	{
		isPlaying = true;

		spawnPoints = GameObject.FindGameObjectsWithTag ("eSpawn");//gather all placed spawn points in an array

		WaveCounter = -1;	//set waves to 0

	//set enemy count based on multipliers from PlayerPrefs
		zombiesLeft = PlayerPrefs.GetInt("zombiesModifierValue") * 15;	//zombies
	
		EnemiesInSwarm = zombiesLeft;	//tally all enemies

		//Debug.Log ("zombies: " + zombiesLeft);
		//Debug.Log ("total: " + EnemiesInSwarm);
		//Debug.Log (PlayerPrefs.GetInt("zombiesModifierValue"));
	}

	//creates the new wave count and enemy amount
	void spawnWave()
	{
		WaveCounter ++;	//inc wave counter
		enemiesToSpawn = 5 + (2 * WaveCounter);	//get number of enemies to spawn

		//wants to spawn more enemies than are left
		if (enemiesToSpawn > EnemiesInSwarm) 
		{
			enemiesToSpawn = EnemiesInSwarm;	//set amount to remaining enemies
		}
	}

	//spawns a certain amount of enemies
	void spawnEnemies()
	{
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);	//random spawn point

		Instantiate(zombie, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.rotation);
		
		enemiesToSpawn = enemiesToSpawn - 1;
		EnemiesInSwarm = EnemiesInSwarm - 1;
		
		StartCoroutine (spawnWait());
	}

	IEnumerator spawnWait ()
	{
		yield return new WaitForSeconds(spawnDelay);
		canSpawn = true;
	}

	//called when the player wins the map
	public void egVictory ()
	{
		
		//save all earnings from the map
		playerCounters.saveEarnings();
		//display victory menu
		vicMenu.SetActive(true);
	}
}
