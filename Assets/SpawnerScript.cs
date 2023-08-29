﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

	public GameObject bombPrefab;
	public GameObject antiBombPrefab;

	// [Not used anymore] private int myInt = 0;
	private float minX = -2.55f;
	private float maxX = 2.55f;

	void Start () {
		StartCoroutine (SpawnBombs());
	}
	
	IEnumerator SpawnBombs()
	{
		yield return new WaitForSeconds (Random.Range(0f, 1f));
		
		if (Random.Range(1, 20) < 4)
		{
			Instantiate(antiBombPrefab, new Vector2(Random.Range(minX, maxX), transform.position.y),
				Quaternion.identity);
		}
		else
		{
			Instantiate(bombPrefab, new Vector2(Random.Range(minX, maxX), transform.position.y),
				Quaternion.identity);
		}

		StartCoroutine (SpawnBombs());

	}


} // class


































