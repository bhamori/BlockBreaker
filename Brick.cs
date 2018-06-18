using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;

    public Sprite[] hitSprites;
    public static int brickCount = 0;
    public AudioClip punch;

	// Use this for initialization
	void Start ()
    {
        //keep track of breakable
        isBreakable = (this.tag == "Breakable");
        if(isBreakable)
        {
            brickCount++;
            print(brickCount);
        }
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        AudioSource.PlayClipAtPoint(punch, transform.position);
        if (isBreakable)
        {
            Handlehits();
        }

    }

    void Handlehits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            brickCount--;
            levelManager.BrickDestroyed();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }


    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }
    
    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}
