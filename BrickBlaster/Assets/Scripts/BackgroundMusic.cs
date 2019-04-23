using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{

	private static BackgroundMusic bgMusic = null; // The static variable responsible for the background music

	private void Awake()
	{
		if (bgMusic != null) // Checks if background music already exits
			Destroy(this.gameObject); // If so, get rid of new one
		else // If background music does not exist
		{
			bgMusic = this; // Set static to the background music
			GameObject.DontDestroyOnLoad(this); // Makes sure it is not destroyed when switching scenes
		}
	}
}
