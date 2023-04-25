using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Vector2 movement;
    public Rigidbody2D player;
    public float runSpeed = 10f;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Sprite runRight;
    public Sprite runLeft;
    public Sprite idle;
    public Sprite swing;
    public float swingTimer;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        if (movement.x > 0)
        {
            //display link running right
            this.gameObject.GetComponent<SpriteRenderer>().sprite = runRight;
            swingTimer = 0;
        }
        else if (movement.x < 0)
        {
            //running left
            this.gameObject.GetComponent<SpriteRenderer>().sprite = runLeft;
            swingTimer = 0;
        }
        else
        {
            //idle
            if (swingTimer == 0)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = idle;
            }
            else
            {
                swingTimer--;
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            this.gameObject.GetComponent<SpriteRenderer>().sprite = swing;
            swingTimer = 10;
        }
    }

    private void FixedUpdate()
    {
        player.MovePosition(player.position + movement * runSpeed * Time.fixedDeltaTime);
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint);
    }
}
