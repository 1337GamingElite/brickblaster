using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

	Paddle player; // Gets the paddle
	LevelManager levelManager; // Gets the level manager (for the lose function)

	AudioSource bounceSound; // The audio source of the ball

	private Rigidbody ball; // The Rigidbody of the ball
	private Vector3 playerToBall; // Offset of ball from player

	public float minimumSpeed; // The minimum speed of the ball
	public float maximumSpeed; // The maximum speed of the ball

	public bool isReleased = false; // If the ball has been launched or not

	private void Start()
	{
		player = FindObjectOfType<Paddle>(); // Gets the paddle/player object
		levelManager = FindObjectOfType<LevelManager>(); // Gets the level manager
		bounceSound = GetComponent<AudioSource>(); // Gets the audio source of the ball
		playerToBall = this.transform.position - player.transform.position; // Sets offset
		ball = GetComponent<Rigidbody>(); // Grabs Rigidbody component of ball
	}

	private void Update()
	{

		if (!isReleased) { 
			this.transform.position = player.transform.position + playerToBall; // Makes sure ball stays with the paddle
			if (Input.GetButtonDown("Fire1") || player.autoPlay) // Instead of Hardcoding Left Click to fire, I used Unity's input system
			{
				isReleased = true; // Ball is launched
				ball.velocity = new Vector3(5f, 10f, 0f); // Initial velocity of ball
			}
		} 

		//Debug.Log(ball.velocity);
	}

	private void OnCollisionEnter(Collision other) {
		float tweak = Random.Range(-5f, 5f); // Random float generated that is added on the x and/or y velocities to switch things up
		if (isReleased)
			bounceSound.Play(); // Plays the bounce sound with every collision after being released
		// This if statement makes sure that the speed (not velocity) is between a certain minimum and maximum value (factoring when the tweaks are added)
		// The speed is the diagonal velocity (used Pythagorean theorem to find out speed given the x and y velocities)
		if (Mathf.Sqrt(((ball.velocity.x + tweak) * (ball.velocity.x + tweak)) + ((ball.velocity.y + tweak) * (ball.velocity.y + tweak))) > minimumSpeed 
			&& Mathf.Sqrt(((ball.velocity.x + tweak) * (ball.velocity.x + tweak)) + ((ball.velocity.y + tweak) * (ball.velocity.y + tweak))) < maximumSpeed)
		{
			// These two if statements makes sure that a single axis' velocity is over 5
			if (ball.velocity.x + tweak < -5f || ball.velocity.x + tweak > 5f)
			{
				ball.velocity = new Vector3(ball.velocity.x + tweak, ball.velocity.y, 0f);
			}
			if (ball.velocity.y + tweak < -5f || ball.velocity.y + tweak > 5f)
			{
				ball.velocity = new Vector3(ball.velocity.x, ball.velocity.y + tweak, 0f);
			}
		}

		// These next 2 if statements prevent the ball from ever moving in a boring straight line path (both x and y)
		if (ball.velocity.y > -2f && ball.velocity.y < 2f)
		{
			if (ball.velocity.y <= 0  && ball.velocity.y -2f > 0)
				ball.velocity = new Vector3(ball.velocity.x, ball.velocity.y - 2f, 0f);
			else
				ball.velocity = new Vector3(ball.velocity.x, ball.velocity.y + 2f, 0f);
		}
		if (ball.velocity.x > -2f && ball.velocity.x < 2f)
		{
			if (ball.velocity.x <= 0)
				ball.velocity = new Vector3(ball.velocity.x - 2f, ball.velocity.y, 0f);
			else
				ball.velocity = new Vector3(ball.velocity.x + 2f, ball.velocity.y, 0f);
		}

		// These last 2 if statements prevent the ball from moving straight up and down near the left and right game borders
		// This checks what border (left or right) the ball is closest to and adds 2f to its velocity in order for it to move away
		// from the border.
		// Its a 'bandaid-fix' to a bug
		if (ball.position.x >= 10.62f)
			ball.velocity = new Vector3(ball.velocity.x - 2f, ball.velocity.y, 0f);
		else if (ball.position.x <= -10.62f)
			ball.velocity = new Vector3(ball.velocity.x + 2f, ball.velocity.y, 0f);

	}

	private void OnTriggerEnter(Collider other) // Since the only trigger is the bottom 'lose' collider, we don't need to check if it is the lose collider
	{
		if (levelManager != null)
			levelManager.LoseGame();
	}

}
