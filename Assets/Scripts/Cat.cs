using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Player
{
    internal float charge = 0;
    internal bool hitbox_exists = false;
    internal float attack_timer = 0f;

    public LayerMask hitbox;

    void Attack()
    {
        RaycastHit2D line = Physics2D.CircleCast(new Vector2(transform.position.x,
            transform.position.y - 0.25f), .75f, new Vector2(direction, 0), .5f, hitbox);

        if (line.collider != null)
        {
            Destroy(line.collider.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RunPhysics();
        if (attack_timer > 0)
        {
            attack_timer -= Time.deltaTime;
            Attack();
        }

        if (Input.GetKey(jumpKey)) {
            charge += Time.deltaTime;
            if (charge > 1)
            {
                speed = starting_speed / 4;
            }
        }
        if (charge > 1.5 && !grounded)
        {
            speed = starting_speed * 2;
        }
    }

    protected override void AirMove()
    {
        Attack();
        attack_timer = 0.5f;
        speed = Mathf.Max(starting_speed, speed);
        charge = 0;
    }
}