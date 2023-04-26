using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;
    public int score;
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
            Instance.textDisplay = textDisplay;
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (textDisplay != null)
        {
            textDisplay.text = score.ToString();
        }
    }
}