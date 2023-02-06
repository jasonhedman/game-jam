using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Player
{
    void Attack()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RunPhysics();

        if (Input.GetKeyUp(KeyCode.C))
        {
            if (grounded)
            {
                grounded = false;
                rb.velocity = new Vector3(rb.velocity.x, jump_height, 0);
            }
            else
            {
                Attack();
            }
        }
    }
}

