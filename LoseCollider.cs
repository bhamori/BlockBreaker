using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;

	void OnTriggerEnter2D(Collider2D trigger)
    {
        //print("Trigger");
        //decrement health
        //if health = 0 lose
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        levelManager.LoadLevel("Lose Screen");
	}
	
	
	void OnCollisionEnter2D (Collision2D collision)
    {
        //print("Collision");
	}
}
