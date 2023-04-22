using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : GameItem
{
    public int xOffset;
    public int yOffset;
    public int points = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        // TODO: Give player points
        if (EnemyManager.Instance.enemies.Contains(this))
        {
            EnemyManager.Instance.enemies.Remove(this);
        }
        Destroy(this.gameObject);
    }
}
