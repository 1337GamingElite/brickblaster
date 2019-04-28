using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

	private int brickCount; // Count of how many breakable bricks in the scene

	private void Start() {
		brickCount = GameObject.FindGameObjectsWithTag("Breakable").Length; // Counts the number of breakable bricks
		Debug.Log(brickCount);
	}

	public void BrickDestroyed() // Method is called when a brick is destroyed
	{
		brickCount--; // Subtract 1 from the brick count
		if (brickCount <= 0) // If brick count is equal or somehow less than 0, the player wins
			Debug.Log("WIN!");
	}

	public void LoseGame() // Function is called when the ball hits the lose collider at the bottom of the play space
	{
		Debug.Log("Lose");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
