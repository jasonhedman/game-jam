using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Player
{
    internal float charge = 0;
    internal bool hitbox_exists = false;
    internal float attack_timer = 0;

    public LayerMask hitbox;

    void Attack()
    {
        RaycastHit2D line = Physics2D.CircleCast(transform.position, 5f, new Vector2(direction, 0), 10, hitbox);
        //RaycastHit2D line = Physics2D.Raycast(transform.position, new Vector2(direction, 0), 20, hitbox);

        if (line.collider != null)
        {
            Debug.Log(line.collider.gameObject);
            Destroy(line.collider.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RunPhysics();

        if (Input.GetKey(jumpKey)) {
            charge += Time.deltaTime;
            if (charge > .5)
            {
                speed = starting_speed / 4;
            }
        }
        else if (Input.GetKeyUp(jumpKey))
        {
            if (grounded)
            {
                if (charge > 1.5)
                {
                    speed = starting_speed * 2;
                }
                charge = 0;
            }
            else
            {
                Attack();
                //attack_timer = 0.5f;
                speed = Mathf.Max(starting_speed, speed);
            }
        }
    }

    protected override void AirMove()
    {
        
    }
}