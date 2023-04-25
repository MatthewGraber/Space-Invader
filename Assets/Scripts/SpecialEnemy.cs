using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpecialEnemy : BasicEnemy
    {
        int width = 10;     // Width of the enemy
        bool goingRight;
        float moveInterval = 15f;
        float y = 15f;

        // Use this for initialization
        void Start()
        {
            if (Random.Range(0, 2) == 0) { 
                goingRight = false;
                moveInterval = -10f;
                setPos(GameManager.Instance.rightEdge);
            }
            else { 
                goingRight = true;
                setPos(GameManager.Instance.leftEdge - width);
            }
        }

        // Update is called once per frame
        void Update()
        {
            setPos(transform.position.x + Time.deltaTime*moveInterval);
            if (moveInterval > 0) {
                if (transform.position.x >= GameManager.Instance.rightEdge)
                {
                    EnemyManager.Instance.specialEnemy = null;
                    Destroy(this.gameObject);
                }
            }
                
            else
            {
                if (transform.position.x <= GameManager.Instance.leftEdge - width)
                {
                    EnemyManager.Instance.specialEnemy = null;
                    Destroy(this.gameObject);
                }
            }
                
        }

        void setPos(float x)
        {
            transform.position = new Vector3(x, y, 1.0f);
        }

    }
}