using Assets.Scripts;
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
    float cooldown = 0f;
    public float cooldownLen;
    public HealthManager healthManager;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        if (cooldown > 0) { cooldown -= Time.deltaTime; }

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
            if (cooldown <= 0)
            {
                Shoot();
                this.gameObject.GetComponent<SpriteRenderer>().sprite = swing;
                swingTimer = 80;
                cooldown = cooldownLen * EnemyManager.Instance.period;
            }
        }

        // Make sure the player is in the world bounds
        if (transform.position.x > GameManager.Instance.rightEdge)
        {
            transform.position = new Vector3(GameManager.Instance.rightEdge, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < GameManager.Instance.leftEdge)
        {
            transform.position = new Vector3(GameManager.Instance.leftEdge, transform.position.y, transform.position.z);
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.gameState == GameState.Playing)
        {
            player.MovePosition(player.position + movement * runSpeed * Time.fixedDeltaTime / EnemyManager.Instance.period);
        }
    }

    private void Shoot()
    {
        if (GameOverManager.gameIsOver == false)
        {
            // Weird bug made the sword move when link was running into the world bounds
            Instantiate(bulletPrefab, firePoint.position, new Quaternion(0f, 0f, 0f, 0f));
        }
    }


}
