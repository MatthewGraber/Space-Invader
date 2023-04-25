using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : GameItem
{
    int HP = 3;

    // Sprites for when the block has 3, 2, or 1 HP
    [SerializeField] Sprite S3;
    [SerializeField] Sprite S2;
    [SerializeField] Sprite S1;
    [SerializeField] SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = S3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage()
    {
        HP--;
        if (HP <= 0 )
        {
            Destroy(this.gameObject);
        }
        else
        {
            SetSprite(HP);
        }
    }


    // Set to the correct sprite based on HP
    void SetSprite(int sprite)
    {
        if (sprite == 2)
        {
            spriteRenderer.sprite = S2;
        }
        else if (sprite == 1)
        {
            spriteRenderer.sprite = S1;
        }
        else
        {
            // If invalid input, do nothing?
        }
    }
}
