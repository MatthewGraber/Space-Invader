using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;
    public int score;
    public static int playerScore;
    public TextMeshProUGUI textDisplay;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            if (textDisplay != null)
            {
                Instance.textDisplay = textDisplay;
            }
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        playerScore = score;
        if (textDisplay != null)
        {
            textDisplay.text = score.ToString();
        }
    }
}