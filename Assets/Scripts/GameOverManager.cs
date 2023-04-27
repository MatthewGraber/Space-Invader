using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public static bool gameIsOver = false;
    public GameObject gameOverUI;

    private void Start()
    {
        gameIsOver = false;
    }
    public void EndGame()
    {
        if (gameIsOver == false)
        {
            gameIsOver = true;
            Debug.Log("Game Over");
            gameOverUI.SetActive(true);

        }

    }
}
