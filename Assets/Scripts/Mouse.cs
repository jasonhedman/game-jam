using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mouse : Player
{
    // Update is called once per frame
    void Update()
    {
        RunPhysics();

        if (Input.GetKeyUp(KeyCode.M))
        {
            //Vector3 ray_start = new Vector3(rb.position.x, rb.position.y - , 0);
            //RaycastHit2D floor = Physics2D.Raycast(ray_start, Vector2.down, 0.2f);

            if (grounded)
            {
                //coyote_timer = -2f; // this is so when it leaves the ground cayote time is 0
                grounded = false;
                rb.velocity = new Vector3(rb.velocity.x, jump_height, 0);
            }
            else
            {
                speed += 1;
                direction *= -1f;
                sr.flipX = !sr.flipX;
            }
        }
    }
}

