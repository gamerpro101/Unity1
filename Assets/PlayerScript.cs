using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	public float speed = 10f;

	private float minX = -2.55f;
	private float maxX = 2.55f;
	private float minY = -4f;
	private float maxY = 4f;

	SpawnerScript spawnerScript;
	public Text scoreText;
	private int score = 0;

	void Awake()
	{
		spawnerScript = GameObject.Find("Spawner").GetComponent<SpawnerScript>();
	}

	public void IncreaseScore()
	{
		score++;

		scoreText.text = "Score: " + score;
		if (score % 60 == 0)
		{

			spawnerScript.LifeUp();
		}

	}
	void Update () {
		MovePlayer ();
	}

	void MovePlayer() {

		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis("Vertical");
		Vector2 currentPosition = transform.position;

		if (h > 0) {
			// going to the right side

			currentPosition.x += speed * Time.deltaTime;

		} else if(h < 0) {
			// going to the left side

			currentPosition.x -= speed * Time.deltaTime;
		}
		if (v > 0)
		{
			// going to the up  side

			currentPosition.y += speed * Time.deltaTime;

		}
		else if (v < 0)
		{
			// going to the down side

			currentPosition.y -= speed * Time.deltaTime;
		}

		if (currentPosition.x < minX) {
			currentPosition.x = minX;
		}

		if (currentPosition.x > maxX) {
			currentPosition.x = maxX;
		}

		if (currentPosition.y < minY)
		{
			currentPosition.y = minY;
		}

		if (currentPosition.y > maxY)
		{
			currentPosition.y = maxY;
		}

		transform.position = currentPosition;

	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "Bomb")
		{
			spawnerScript.SubtractLife();

		}
		if (target.tag == "AntiBomb")
		{
			IncreaseScore();
			target.gameObject.SetActive(false);
		}
	}

} // class








































