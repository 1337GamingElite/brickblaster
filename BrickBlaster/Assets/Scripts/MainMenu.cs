using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
	public void StartGame()
	{
		SceneManager.LoadSceneAsync(1, LoadSceneMode.Single); // Loads the first level
	}

	public void QuitGame()
	{
		Application.Quit(); // Quits the game
	}

}
