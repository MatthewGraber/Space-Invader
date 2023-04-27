using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    public int health = 5;
    public Image[] hearts;
    public Sprite heartIMG;

    private void Start()
    {
        
    }

    private void Update()
    {
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
    }

    public void takeDamage()
    {
        health--;
    }
}
