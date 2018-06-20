using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    // Use this for initialization
    public bool autoPlay = false;

    private Ball ball;

	void Start ()
    {
        ball = GameObject.FindObjectOfType<Ball>();
	}

    // Update is called once per frame
    
    
	void Update ()
    {
        if(!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
    }

    void MoveWithMouse()
    {
        float mousePos = (Input.mousePosition.x / Screen.width) * 16;
        //print("x = " + mousePos);
        Vector3 paddlePos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        paddlePos.x = Mathf.Clamp(mousePos, 0.65f, 15.35f);
        this.transform.position = paddlePos;
    }

    void AutoPlay()
    {
        Vector3 ballPos = ball.transform.position;
        //print("x = " + mousePos);
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        paddlePos.x = Mathf.Clamp(ballPos.x, 0.65f, 15.35f);
        this.transform.position = paddlePos;
    }
}
