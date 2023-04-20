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

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
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
