using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("GameScene");
    }

    public void SeeInstructions()
    {
        SceneManager.LoadSceneAsync("InstructionScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
