using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : GameItem
{
    public int xOffset;
    public int yOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPosition(int x, int y)
    {
        //transform.position.Set(x + xOffset, y + yOffset, 0);
        transform.position = new Vector3(x + xOffset, y + yOffset, 1.0f);
    }
}
