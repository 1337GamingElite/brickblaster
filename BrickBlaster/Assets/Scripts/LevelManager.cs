using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

	private int brickCount; // Count of how many breakable bricks in the scene

	public static bool uiOpen = false; // If a UI is open (Used to prevent player movement

	// The Win or Lose UI objects
	public GameObject winUI;
	public GameObject loseUI;
	
	// The rigidbody of the ball (used to freeze it when player wins)
	Rigidbody ball; 

	private void Start() {
		uiOpen = false; // Makes sure uiOpen is false everytime a level starts
		brickCount = GameObject.FindGameObjectsWithTag("Breakable").Length; // Counts the number of breakable bricks
		ball = FindObjectOfType<Ball>().GetComponent<Rigidbody>(); // Gets the ball's rigidbody
		//Debug.Log(brickCount);
	}

	public void BrickDestroyed() // Method is called when a brick is destroyed
	{
		brickCount--; // Subtract 1 from the brick count
		if (brickCount <= 0) // If brick count is equal or somehow less than 0, the player wins
			WinGame();
	}

	void WinGame()
	{
		Cursor.visible = true; // Makes the cursor visible for UI
		ball.velocity = new Vector3(0f, 0f, 0f); // Stops the ball
		uiOpen = true; // UI is open
		winUI.SetActive(true); // Turns on the win ui
		//Debug.Log("Win!");
	}

	public void LoseGame() // Function is called when the ball hits the lose collider at the bottom of the play space
	{
		Cursor.visible = true; // Makes the cursor visible for UI
		ball.velocity = new Vector3(0f, 0f, 0f); // Stops the ball
		uiOpen = true; // UI is open
		loseUI.SetActive(true); // Turns on the lose UI
	}

	//
	// -------- UI BUTTON FUNCTIONS ---------
	//

	public void LoadNextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void ReloadLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void LoadMainMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

}
