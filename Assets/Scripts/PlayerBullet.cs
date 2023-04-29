using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float projectileSpeed = 10f;
    public Rigidbody2D bullet;
    public GameObject Bullet;

    private void Start()
    {
        bullet.velocity = transform.up * projectileSpeed / EnemyManager.Instance.period;
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.y >= GameManager.Instance.topEdge)
        {
            Destroy(Bullet);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            BasicEnemy enemy = collision.GetComponent<BasicEnemy>();
            if (enemy != null)
            {
                enemy.TakeDamage();
            }

            Destroy(this.gameObject);
        }
        else if (collision.tag == "Block")
        {
            Block block = collision.GetComponent<Block>();
            if (block != null)
            {
                block.TakeDamage();
            }

            Destroy(this.gameObject);
        }
    }
}
