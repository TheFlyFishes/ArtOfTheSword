/// <summary>
/// This script changes the value of text and a playerPrefs variable every
/// time the scroll bar is changed. 
/// </summary>
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class GUI_scrollBarEnemyDensity : MonoBehaviour {

	public Slider sliderUnit;
	int sliderValue;
	public Text densityDisplay;
	string[] densityArray = {"None", "Low", "Medium", "High", "Swarming"};
	string plPrefName;

	public void Start()
	{
		//Determines the name of the PlayerPrefs var to change
		//gets the text objects name and adds 'ModifierValue to it
		//result ex: 'zombieModifierValue'
		plPrefName = string.Concat((densityDisplay.name).ToString(),"ModifierValue");
		//Adds a listener to the main slider and invokes a method when the value changes.
		sliderUnit.onValueChanged.AddListener (delegate {changeText ();});
		
		//Debug.Log ("playerPrefs Var Name:" + plPrefName);
	}

	void changeText()
	{
		sliderValue = (int) sliderUnit.value;
		densityDisplay.text = densityArray[sliderValue];
		PlayerPrefs.SetInt (plPrefName, sliderValue);

		//Debug.Log (plPrefName + " = " + PlayerPrefs.GetInt(plPrefName));
	}
}
