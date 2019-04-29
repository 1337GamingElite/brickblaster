using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paddle : MonoBehaviour
{

	// Since the game is in 3d, the mouse movement system has to be changed
	// It hides the cursor and detects the CHANGE in mouse X position
	// Code from part of: https://answers.unity.com/questions/1041596/how-can-i-use-both-mouse-and-keyboard-to-do-the-sa.html

	public static float paddleSpeed = 0.6f; // The speed of the paddle (used mainly as a scale factor to align mouse movements)
	public bool autoPlay = false; // Autoplay mode
	Ball ball; // The ball

	private void Start()
	{
		if (SceneManager.GetActiveScene().buildIndex != 0) // Hides the cursor except on the main menu
		{
			Cursor.lockState = CursorLockMode.Confined; // Locks the cursor to the game window (prevents it from being dragged off the game)
			Cursor.visible = false; // Hides the cursor
		}
		ball = GameObject.FindObjectOfType<Ball>(); // Gets the ball
	}

	// Update is called once per frame
	void Update()
    {
		if (!autoPlay) // If autoplay is unchecked, it uses mouse movement
			MouseMovement();
		else
			AutoPlay();
    }

	void AutoPlay()
	{
		Vector3 ballPos = ball.transform.position; // Gets the ball's position
		Vector3 playerPos = new Vector3(Mathf.Clamp(ballPos.x, -8.9f, 8.9f), -4.28f, -5f); // The player's position would always have the same x as the ball
		this.transform.position = playerPos; // Sets player position to always be aligned with the ball
	}

	void MouseMovement()
	{
		// It uses Unity's input system
		// Input.GetAxis("Mouse X") gets the change in mouse position in the x axis
		// This is then added onto the paddle's x then multiplied by the speed
		if (!LevelManager.uiOpen) // Checks if a UI is not open (prevents movement if player wins or loses the level when the UI is open)
		{
			float paddleX = this.transform.position.x + Input.GetAxis("Mouse X") * paddleSpeed;
			Vector3 playerPos = new Vector3(Mathf.Clamp(paddleX, -8.9f, 8.9f), -4.28f, -5f);
			this.transform.position = playerPos;
		}
	}
}
