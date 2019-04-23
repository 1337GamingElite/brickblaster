using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectRatioFix : MonoBehaviour
{
	// Due to the 3D perspective camera, different window aspect ratio will result in parts of the screen being cut off
	// To fix this, this script will force the camera into a standard 16:9 ratio, and will make black bars if the screen is any other ratio
	// Source: http://gamedesigntheory.blogspot.com/2010/09/controlling-aspect-ratio-in-unity.html

	public Camera camera; //The camera component so that we can change its view

	private void Start()
	{
		float targetAspect = 16.0f / 9.0f; // The target aspect ratio
		float currentAspect = (float)Screen.width / (float)Screen.height; // The current screen's aspect ratio
		float scaleH = currentAspect / targetAspect; // Multiplier for the window's height

		if (scaleH < 1.0f) // If the height scaled is smaller than the current height, add black bars on top (letterbox)
		{
			Rect rect = camera.rect; // Gets camera box
			rect.width = 1.0f; // 100% width
			rect.height = scaleH; // Set to scaled height
			rect.x = 0; // Centered on x
			rect.y = (1.0f - scaleH) / 2.0f; // Centers camera on y

			camera.rect = rect; // Adds the letterbox
		}
		else // If height scaled is greater, add pillar box (boxes on the left and right sides)
		{
			float scaleW = 1.0f / scaleH; // The camera's width scale

			Rect rect = camera.rect; // Gets camera box
			rect.width = scaleW; // Set to scaled width
			rect.height = 1.0f; // 100% heigh
			rect.x = (1.0f - scaleW) / 2.0f; // Centers camera on x
			rect.y = 0; // Centered on y

			camera.rect = rect; // Adds the pillar box
		}
	}
}
