using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

	// Since the game is in 3d, the mouse movement system has to be changed
	// It hides the cursor and detects the CHANGE in mouse X position
	// Code from part of: https://answers.unity.com/questions/1041596/how-can-i-use-both-mouse-and-keyboard-to-do-the-sa.html

	public float paddleSpeed = 0.6f; // The speed of the paddle (used mainly as a scale factor to align mouse movements)

	private void Start()
	{
		Cursor.visible = false; // Hides the cursor
	}

	// Update is called once per frame
	void Update()
    {
		// It uses Unity's input system
		// Input.GetAxis("Mouse X") gets the change in mouse position in the x axis
		// This is then added onto the paddle's x then multiplied by the speed
		float paddleX = this.transform.position.x + Input.GetAxis("Mouse X") * paddleSpeed;  
		Vector3 playerPos = new Vector3(Mathf.Clamp(paddleX, -8.9f, 8.9f), -4.28f, -5f);
		this.transform.position = playerPos;
    }
}
