using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : GameItem
{
    public int xOffset;
    public int yOffset;
    public int points = 10;
    public EnemyBullet bulletPrefab;

    float timeToFire;

    // Start is called before the first frame update
    void Start()
    {
        if (ID == 2)
        {
            timeToFire = Random.Range(1f, 15f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ID == 2)
        {
            timeToFire -= Time.deltaTime;
            
            if (timeToFire <= 0)
            {
                Fire();
                timeToFire = Random.Range(1f, 15f);
            }
        }
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

    public void SetPosition(int x, int y)
    {
        //transform.position.Set(x + xOffset, y + yOffset, 0);
        transform.position = new Vector3(x + xOffset, y + yOffset, 1.0f);
    }

    public void Fire()
    {
        Instantiate(bulletPrefab, transform);
    }
}
