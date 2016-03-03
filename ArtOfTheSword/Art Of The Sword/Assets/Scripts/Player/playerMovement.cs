/// <summary>
/// This script handles player movement.
/// </summary>
using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour{

	public float speed = 0.2f;



	void Awake ()
	{
	}

	void Update () {
		//Movement controls
		if (Input.GetKey (KeyCode.D)) 
		{
			//transform.Translate (Vector2.right * speed);
			transform.position += Vector3.right * speed;
		}
		if (Input.GetKey (KeyCode.W)) 
		{
			transform.Translate (Vector2.up * speed);
		}
		if (Input.GetKey (KeyCode.A)) 
		{
			transform.Translate (Vector2.left * speed);
		}
		if (Input.GetKey (KeyCode.S)) 
		{
			transform.Translate (Vector2.down * speed);
		}
	}
}