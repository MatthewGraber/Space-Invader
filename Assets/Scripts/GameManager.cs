using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameState gameState;
    public static GameManager Instance;
    public int level = 0;

    public int leftEdge;
    public int rightEdge;
    public int topEdge;
    public int bottomEdge;

    public int width => rightEdge - leftEdge;
    public int height => topEdge - bottomEdge;

    [SerializeField] Player player;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        changeState(GameState.BeginingLevel);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == GameState.Playing)
        {
            int state = EnemyManager.Instance.CurrentState();
            if (state == 1)
            {
                changeState(GameState.BeginingLevel);
            }
            else if (state == -1)
            {
                print("Enemies won");
                changeState(GameState.Dying);
            }
            else if (player.healthManager.health <= 0)
            {
                print("Player died");
                changeState(GameState.Dying);
            }
        }
    }


    // Update gamestate
    public void changeState(GameState state)
    {
        gameState = state;
        if (state == GameState.BeginingLevel)
        {
            if (level == 0)
            {
                EnemyManager.Instance.Reset();
                BlockManager.Instance.SpawnBlocks();
                Score.Instance.score = 0;
            }
            else
            {
                EnemyManager.Instance.NextLevel();
            }
            level++;
            changeState(GameState.Playing);
        }
        else if (state == GameState.Playing)
        {

        }
        else if (state ==  GameState.Dying)
        {
            SceneManager.LoadScene("ScoreScene");
        }

    }

}

public enum GameState
{
    BeginingLevel,
    Playing,
    Dying,
}