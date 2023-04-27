using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TMP_InputField inputField;
    public Button menu;
    public string playerName;
    public ScoreManager scoreManager;
    public int score;

    private void OnEnable()
    {
        score = Score.playerScore;
        scoreText.text = "Score: " + score.ToString();
    }

    public void SaveScore()
    {
        playerName = inputField.text;
        Debug.Log(playerName);
        scoreManager.AddScore(new ScoreInfo(playerName, score));
        Debug.Log("Score Saved");
        menu.interactable = false;
        Invoke("Menu", 1f);
    }
    public void Menu()
    {
        SceneManager.LoadScene("ScoreScene");
    }
}
