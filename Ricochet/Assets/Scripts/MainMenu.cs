using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{

    List<string> LevelNames = new List<string>();
    bool sceneLoaded = false;

	public void Start()
	{
        LevelNames.Add("Level1");
		LevelNames.Add("Level2");
		LevelNames.Add("Level3");
	}

	public void PlayGame()
    {
        if(!sceneLoaded)
        {
            SceneManager.LoadScene(LevelNames[Random.Range(0,3)]);
            sceneLoaded = true;
        }

       
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
