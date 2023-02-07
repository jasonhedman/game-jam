using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public float starting_speed = 5;
    internal float speed;
    internal float direction;
    public float jump_height = 10;

    internal Rigidbody2D rb;
    internal SpriteRenderer sr;

    internal bool grounded = true;
    internal float coyote_timer = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        speed = starting_speed;
        direction = 1;
    }

    public void RunPhysics()
    {
        if (coyote_timer > 0)
        {
            coyote_timer -= Time.deltaTime;
            if (!(coyote_timer > 0))
            {
                grounded = false;
            }
        }

        rb.velocity = new Vector3(speed * direction, rb.velocity.y, 0);

        if (speed > starting_speed)
        {
            speed -= Time.deltaTime;
            speed = Mathf.Min(starting_speed * 2f, speed);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stage"))
        {
            coyote_timer = 0.2f;
            if (coyote_timer < -1)
            {
                coyote_timer = 0;
            }
            else coyote_timer = 0.1f;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stage"))
        {
            grounded = true;
            coyote_timer = 0;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(gameObject);
        if (collision.gameObject.CompareTag("Wall") || (collision.gameObject.CompareTag("Player") && coyote_timer <= 0))
        {
            grounded = true;
            coyote_timer = 0.1f;

            if (transform.position.x > collision.gameObject.transform.position.x)
            {
                if (direction == -1) {
                    direction = 1;
                    sr.flipX = !sr.flipX;
                }
            }
            else
            {
                if (direction == 1)
                {
                    direction = -1;
                    sr.flipX = !sr.flipX;
                }
            }
            //Debug.Log(collision.gameObject);
        }
    }
}
