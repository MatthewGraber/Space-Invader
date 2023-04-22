using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpecialEnemy : BasicEnemy
    {
        int width;
        bool goingRight;
        float x;
        float moveInterval = 0.1f;

        // Use this for initialization
        void Start()
        {
            if (Random.Range(0, 2) == 0) { 
                goingRight = false;
                moveInterval = -0.1f;
                x = GameManager.Instance.rightEdge;
            }
            else { 
                goingRight = true;
                x = GameManager.Instance.leftEdge - width;
            }
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector3(x + Time.deltaTime*moveInterval, 20f, 1.0f);
            if (moveInterval > 0)
                if (transform.position.x >= GameManager.Instance.rightEdge)
                { // Destroy
                }
            else
                if (transform.position.x <= GameManager.Instance.leftEdge - width)
                {
                    // Destroy
                }
        }
        
    }
}