using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //To quit the game lol
    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void startButton()
    {
        SceneManager.LoadScene("PlayScene");
    }
    
    public void toScores()
    {
        SceneManager.LoadScene("ScoreScene");
    }

    public void toMain()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
