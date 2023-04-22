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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum GameState
{

}