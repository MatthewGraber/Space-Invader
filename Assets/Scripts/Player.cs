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
    public Sprite idleRight;
    public Sprite idleLeft;
    public float swingTimer;
    public float animTimer = 10f;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        //Lord help me. This is a crazy nested if statement
        if (swingTimer < 20)
        {
            if (movement.x > 0)
            {
                //display link running right
                if (0 < animTimer && animTimer <= 25)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = runRight;
                    animTimer--;
                }
                else if (animTimer > 25)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = idleRight;
                    animTimer--;
                }
                else if (animTimer >= 0)
                {
                    animTimer = 50;
                }
                swingTimer = 0;
            }
            else if (movement.x < 0)
            {
                //running left
                if (0 < animTimer && animTimer <= 25)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = runLeft;
                    animTimer--;
                }
                else if (animTimer > 25)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = idleLeft;
                    animTimer--;
                }
                else if (0 >= animTimer)
                {
                    animTimer = 50;
                }
                swingTimer = 0;
            }
            else
            {
                //idle when not swinging
                if (swingTimer < 0)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = idle;
                }
                else
                {
                    //swinging the sword
                    swingTimer--;
                }
            }
        }

        swingTimer--;

        if (Input.GetButtonDown("Fire1"))
        {
            if (swingTimer < 20)
            {
                Shoot();
                this.gameObject.GetComponent<SpriteRenderer>().sprite = swing;
                swingTimer = 80;
            }
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
