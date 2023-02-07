using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Player
{
    internal float charge = 0;
    internal bool hitbox_exists = false;

    public GameObject LeapHitbox;

    void Attack()
    {
        speed = Mathf.Max(starting_speed, speed);
        //Instantiate(LeapHitbox);
        //hitbox_exists = true;
        //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), LeapHitbox.GetComponent<Collider2D>());

        //for (int i = 0; i < 9; i++) {
        //    Vector3 angle = Vector2.down;
        //    RaycastHit2D down = Physics2D.Raycast(transform.position, angle, 3);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        RunPhysics();

        //if (hitbox_exists)
        //{
        //    LeapHitbox.transform.position = transform.position;
        //    if (grounded)
        //    {
        //        Destroy(LeapHitbox);
        //        hitbox_exists = false;
        //    }
        //}

        if (Input.GetKey(KeyCode.C)) {
            charge += Time.deltaTime;
            if (charge > .5)
            {
                speed = starting_speed / 4;
            }
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            if (grounded)
            {
                if (charge > 1.5)
                {
                    speed = starting_speed * 2;
                }
                charge = 0;
                grounded = false;
                //coyote_timer = -0.2f;
                rb.velocity = new Vector3(rb.velocity.x, jump_height, 0);
            }
            else
            {
                Attack();
            }
        }
    }
}

