using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float projectileSpeed = 5f;
    public Rigidbody2D bullet;
    public GameObject Bullet;

    private void Start()
    {
        bullet.velocity = transform.up * projectileSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.y >= 5)
        {
            Destroy(Bullet);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Enemy")
        {
            BasicEnemy enemy = collision.GetComponent<BasicEnemy>();
            if (enemy != null)
            {
                enemy.TakeDamage();
            }

            Destroy(this.gameObject);
        }
    }
}
