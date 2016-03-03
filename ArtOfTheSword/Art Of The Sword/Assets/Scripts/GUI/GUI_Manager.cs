//conatins all general interaction with menu objects
//includes button click events, toggles, and slider effects
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUI_Manager : MonoBehaviour {
	//disables a game object
	public void disableGameObject(GameObject objectToDisable)
	{
		objectToDisable.SetActive(false);

	}
	//enables a game object
	public void enableGameObject(GameObject objectToEnable)
	{
		objectToEnable.SetActive(true);

	}
	//changes to a given scene
	public void changeScene(int sceneChangesTo)
	{
		Application.LoadLevel (sceneChangesTo);
	}
	//Exits the game|shut down applicaton
	public void shutDown()
	{
		Application.Quit();
	}
}