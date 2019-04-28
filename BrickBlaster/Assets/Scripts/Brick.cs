using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
	int hitCount; // Amount of hits the brick has taken
	public Material[] hitMaterials; // The array of materials the brick has
	LevelManager levelManager; // The scene's level manager
	Renderer brickMat; // The current material the brick has
	 
	public GameObject breakSound; // The prefab responsible for the break sound
	public GameObject particles;

	private void Start()
	{
		hitCount = 0; // Resets hit count to 0
		brickMat = GetComponent<Renderer>(); // Gets the current brick's renderer component
		levelManager = FindObjectOfType<LevelManager>(); // Gets the scene's level manager
		brickMat.material = hitMaterials[hitMaterials.Length - 1]; // Sets the current material of the brick to the last on in the array
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (gameObject.tag == "Breakable") // Only destroys if it is tagged as breakable
		{
			hitCount++; // Add 1 to hit
			int health = hitMaterials.Length; // Health is equal to amount of materials in the array
			//Debug.Log(health);
			//Debug.Log(hitCount);
			if (hitCount >= health) { // If hit count exceeds or equals health, the block will be destroyed
				GameObject breakObject = Instantiate(breakSound, this.transform.position, Quaternion.identity); // Creates the audio 'crack' prefab
				Destroy(breakObject, 1f); // Destroys the audio source after 1 second
				GameObject newParticles = Instantiate(particles, this.transform.position, Quaternion.identity); // Creates a new particle 
				ParticleSystem ps = newParticles.GetComponent<ParticleSystem>(); // Gets the particle system
				ps.startColor = brickMat.material.color; // Sets the particle color to the material's color (due to the nature of the materials, when destroyed, it will always be yellow
				Destroy(newParticles, 1f); // Destroy the particle game object after 1 second
				if (levelManager != null) // Checks if there is a level manager (the main menu doesn't need one)
					levelManager.BrickDestroyed(); // Calls the BrickDestoryed() method in the level manager class | Used for detecting a win condition
				Destroy(this.gameObject); // Destroys the brick
			}
			else
				ChangeMaterial(); // If brick still has health, change its material to the next one in the array
		}
	}

	private void ChangeMaterial() 
	{
		int newMaterial = hitMaterials.Length - hitCount - 1; // The new material is equal to the one before the current
		brickMat.material = hitMaterials[newMaterial]; // Sets the current material to the new one
	}

}
