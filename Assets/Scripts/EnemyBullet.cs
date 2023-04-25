using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyBullet : GameItem
    {

        public float projectileSpeed = -3f;
        public Rigidbody2D bullet;
        public GameObject Bullet;

        private void Start()
        {
            bullet.velocity = transform.up * projectileSpeed;
        }

        // Update is called once per frame
        void Update()
        {

            if (transform.position.y <= GameManager.Instance.bottomEdge)
            {
                Destroy(Bullet);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            print("Collision with " + collision.tag);
            if (collision.tag == "Player")
            {
                HealthManager playerHealth = collision.GetComponent<HealthManager>();
                if (playerHealth != null)
                {
                    playerHealth.takeDamage();
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
}