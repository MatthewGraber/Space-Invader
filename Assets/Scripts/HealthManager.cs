using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    public int health;
    public Image[] hearts;
    public Sprite heartIMG;

    private void Start()
    {
        health = 5;
    }

    private void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            health--;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            // TODO: Make this work
            if (i < health)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        if (health == 0)
        {
            //FindObjectOfType<GameOverManager>().EndGame();
        }
    }

    public void takeDamage()
    {
        health--;
    }
}
