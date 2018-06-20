using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    string levelName;

	public void LoadLevel(string name){
        //Debug.Log ("New Level load: " + name);
        Brick.brickCount = 0;
        SceneManager.LoadScene(name);
        this.levelName = name;

        if (name == "Start Menu" || name == "Lose Screen" || name == "Win Screen")
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
        
	}

    public void QuitRequest()
    {
        //Debug.Log("Quit requested");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        Brick.brickCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        this.levelName = SceneManager.GetActiveScene().ToString(); 

        if (levelName == "Start menu" || levelName == "Lose Screen" || levelName == "Win Screen")
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
    }

    public void BrickDestroyed()
    {
        if(Brick.brickCount <= 0)
        {
            LoadNextLevel();
        }
    }

}
