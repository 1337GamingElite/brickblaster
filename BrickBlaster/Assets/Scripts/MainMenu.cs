using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;

public class MainMenu : MonoBehaviour
{

	// The empty objects responsible for toggling between settings and the main menu
	public GameObject mainMenu;
	public GameObject settingsMenu;

	public AudioMixer audioMix; // The audio mix responsible for the master, music, and sfx volumes

	// Labels for the sliders
	public TextMeshProUGUI sensLabel;
	public TextMeshProUGUI masterLabel;
	public TextMeshProUGUI musicLabel;
	public TextMeshProUGUI sfxLabel;


	//
	// -------- SETTINGS MENU ---------
	//

	public void PlayerSensitivity(float sens)
	{
		Paddle.paddleSpeed = sens; // Sets slider float to player sensitivity
		sensLabel.text = sens.ToString("0.00"); // Sets the sensitivity label to the slider's value, rounded to 2 decimals
	}


	// The next 3 functions change the volumes
	public void MasterVolume(float vol)
	{
		masterLabel.text = (vol * 100f).ToString("0") + "%"; // Turns the slider value into a percent which will be used for the label
		float newVolume = Mathf.Log10(vol) * 20f; // Converts the linear slider (0.001-1) into decibels (https://www.youtube.com/watch?v=xNHSGMKtlv4)
		audioMix.SetFloat("MasterVolume", newVolume); // Sets the volume
	}

	public void MusicVolume(float vol)
	{
		musicLabel.text = (vol * 100f).ToString("0") + "%"; // Turns the slider value into a percent which will be used for the label
		float newVolume = Mathf.Log10(vol) * 20f; // Converts the linear slider (0.001-1) into decibels (https://www.youtube.com/watch?v=xNHSGMKtlv4)
		audioMix.SetFloat("MusicVolume", newVolume); // Sets the volume
	}

	public void SFXVolume(float vol)
	{
		sfxLabel.text = (vol * 100f).ToString("0") + "%"; // Turns the slider value into a percent which will be used for the label
		float newVolume = Mathf.Log10(vol) * 20f; // Converts the linear slider (0.001-1) into decibels (https://www.youtube.com/watch?v=xNHSGMKtlv4)
		audioMix.SetFloat("SFXVolume", newVolume); // Sets the volume
	}

	// Closes the settings menu
	public void CloseSettings()
	{
		settingsMenu.SetActive(false);
		mainMenu.SetActive(true);
	}

	//
	// -------- MAIN MENU ---------
	//

	public void StartGame()
	{
		SceneManager.LoadSceneAsync(1, LoadSceneMode.Single); // Loads the first level
	}

	public void QuitGame()
	{
		Application.Quit(); // Quits the game
	}

	// Opens the settings menu
	public void OpenSettings()
	{
		mainMenu.SetActive(false);
		settingsMenu.SetActive(true);
	}

}
