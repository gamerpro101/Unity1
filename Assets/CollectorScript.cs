using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectorScript : MonoBehaviour {


	PlayerScript playerScript;
	SpawnerScript spawnerScript;
    void Awake()
    {
		playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
		spawnerScript = GameObject.Find("Spawner").GetComponent<SpawnerScript>();
    }
    void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "Bomb") {
			playerScript.IncreaseScore ();
			target.gameObject.SetActive (false);
		}
		if (target.tag == "AntiBomb")
        {
			spawnerScript.SubtractLife();
		}
	}

}
