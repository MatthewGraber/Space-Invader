using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;
    public int score;
    public TextMeshPro scoreDisplay;
    [SerializeField] GameObject textDisplay;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        textDisplay.TryGetComponent<TextMeshPro>(out Instance.scoreDisplay);
    }

    private void Update()
    {
        if (scoreDisplay!= null)
        {
            scoreDisplay.text = score.ToString();
        }
    }
}