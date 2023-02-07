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

    // is this a problem that theyre private?
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stage"))
        {
            coyote_timer = 0.2f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stage"))
        {
            grounded = true;
            coyote_timer = 0;
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            direction *= -1;
            sr.flipX = !sr.flipX;
        }
    }
}
