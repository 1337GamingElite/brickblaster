using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

	public Paddle player; // Gets the paddle

	private Rigidbody ball; // The Rigidbody of the ball
	private Vector3 playerToBall; // Offset of ball from player

	bool isReleased = false; // If the ball has been launched or not

	private void Start()
	{
		playerToBall = this.transform.position - player.transform.position; // Sets offset
		ball = GetComponent<Rigidbody>(); // Grabs Rigidbody component of ball
	}

	private void Update()
	{

		if (!isReleased) { 
			this.transform.position = player.transform.position + playerToBall; // Makes sure ball stays with the paddle
			if (Input.GetButtonDown("Fire1")) // Instead of Hardcoding Left Click to fire, I used Unity's input system
			{
				isReleased = true; // Ball is launched
				ball.velocity = new Vector3(5f, 10f, 0f); // Initial velocity of ball
			}
		}
		
	}

}
