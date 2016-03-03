using UnityEngine;
using System.Collections;


//Generates the level tiles based on conditions
public class LevelGenerator : MonoBehaviour
{
	//map tiles
	public GameObject tileGrass;
	public GameObject tileWater;
	public GameObject tileLeftWall;
	public GameObject tileRightWall;
	public GameObject tileTopWall;
	public GameObject tileBotWall;

	public GameObject tileTopLeft;
	public GameObject tileTopRight;
	public GameObject tileBotLeft;
	public GameObject tileBotRight;
	
	public GameObject levelMaster;
	public GameObject playerChar;
	public GameObject theVoid;

	static int maxHeight = 30;
	static int maxWidth = 30;
	int indHeight = 0;
	int indWidth = 0;

	float randomNumber = 0;
	float tileWidth = 0.32f;
	float tileHeight = 0.32f;
	float pointerWidth = 0;
	float pointerHeight = 0;

	//map array
	//GameObject [,] MapArray = new GameObject[maxWidth, maxHeight];

	void Awake ()
	{
		generateLevel ();
	}

	void generateLevel()
	{


		while(indHeight <= maxHeight)
		{
			while(indWidth <= maxWidth)
			{
			//generate corners
				//generate top left corner
				if (indWidth == 0)
				{
					if(indHeight == maxHeight)
					{Instantiate(tileTopLeft, new Vector2(pointerWidth, pointerHeight), Quaternion.identity);}
				
					//generate bottom left
					if(indHeight == 0)
					{Instantiate(tileBotLeft, new Vector2(pointerWidth, pointerHeight), Quaternion.identity);}
				}
				if(indWidth == maxWidth)
				{
					//generate top right
					if(indHeight == maxHeight)
					{Instantiate(tileTopRight, new Vector2(pointerWidth, pointerHeight), Quaternion.identity);}
				
					//generate bottom right
					if(indHeight == 0)
					{Instantiate(tileBotRight, new Vector2(pointerWidth, pointerHeight), Quaternion.identity);}
				}
			//generate borders
				if(indHeight != 0 && indHeight != maxHeight)
				{
					//generate left wall
					if(indWidth == 0)
					{Instantiate(tileLeftWall, new Vector2(pointerWidth, pointerHeight), Quaternion.identity);}

					//generate right wall
					if(indWidth == maxWidth)
					{Instantiate(tileRightWall, new Vector2(pointerWidth, pointerHeight), Quaternion.identity);}
				}
				if(indWidth != 0 && indWidth != maxWidth)
				{
					//generate top wall
					if(indHeight == maxHeight)
					{Instantiate(tileTopWall, new Vector2(pointerWidth, pointerHeight), Quaternion.identity);}

					//generate bottom wall
					if(indHeight == 0)
					{Instantiate(tileBotWall, new Vector2(pointerWidth, pointerHeight), Quaternion.identity);}
				}
			//Spawn tile
				if(indHeight != 0 && indHeight != maxHeight && indWidth != 0 && indWidth != maxWidth)
				{
					//generate random number
					randomNumber = Random.Range(1F, 100F);
					
					if(randomNumber < 30)
					{
						//MapArray[indWidth, indHeight] = Instantiate (tileWater);
						Instantiate(tileWater, new Vector2(pointerWidth, pointerHeight), Quaternion.identity);
					}
					if(randomNumber >= 30)
					{
						//MapArray[indWidth, indHeight] = Instantiate (tileGrass);
						Instantiate(tileGrass, new Vector2(pointerWidth, pointerHeight), Quaternion.identity);
					}
				}

				pointerWidth = pointerWidth + tileWidth;
				indWidth++;
			}

			pointerWidth = 0;
			indWidth = 0;
			pointerHeight = pointerHeight + tileHeight;
			indHeight++;
		}

		//Place the player's character
		pointerHeight = pointerHeight / 2;
		Instantiate(playerChar, new Vector2(pointerHeight, pointerHeight), Quaternion.identity);
		Instantiate(theVoid, new Vector2(pointerHeight, pointerHeight), Quaternion.identity);
	}
}