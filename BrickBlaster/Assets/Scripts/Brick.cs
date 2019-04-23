using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
	public int health;
	public int hitCount;

	private void Start()
	{
		hitCount = 0;
	}

	private void OnCollisionEnter(Collision collision)
	{
		health--;
		if (health <= 0)
			Destroy(this.gameObject);
	}

}
