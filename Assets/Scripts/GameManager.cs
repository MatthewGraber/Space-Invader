using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
    }


    // Update gamestate
    public void changeState(GameState state)
    {
        if (state == GameState.BeginingLevel)
        {
            if (level == 0)
            {
                EnemyManager.Instance.Reset();
            }
            else
            {
                EnemyManager.Instance.NextLevel();
            }
            level++;
        }
        else if (state == GameState.Playing)
        {

        }
        else if (state ==  GameState.Dying)
        {

        }

        gameState = state;
    }
}

public enum GameState
{
    BeginingLevel,
    Playing,
    Dying,
}