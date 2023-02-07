using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public float starting_speed = 5;
    internal float speed;
    internal float direction = 1;
    public float jump_height = 10;

    internal Rigidbody2D rb;
    internal SpriteRenderer sr;

    internal bool grounded = true;
    //internal float coyote_timer = 0.25f;

    public KeyCode jumpKey;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        speed = starting_speed;
    }

    public void RunPhysics()
    {
        //if (coyote_timer > 0)
        //{
        //    coyote_timer -= Time.deltaTime;
        //    if (!(coyote_timer > 0))
        //    {
        //        grounded = false;
        //    }
        //}

        rb.velocity = new Vector3(speed * direction, rb.velocity.y, 0);

        if (Input.GetKeyUp(jumpKey))
        {
            if(IsGrounded())
            {
                Jump();
            }
        }

        if (speed > starting_speed)
        {
            speed -= Time.deltaTime;
            speed = Mathf.Min(starting_speed * 2f, speed);
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jump_height, 0);
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Stage"))
    //    {
    //        coyote_timer = 0.2f;
    //        if (coyote_timer < -1)
    //        {
    //            coyote_timer = 0;
    //        }
    //        else coyote_timer = 0.1f;
    //    }
    //}

    private void OnCollisionStay2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Stage"))
        //{
        //    grounded = true;
        //    //coyote_timer = 0;
        //}
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Player"))
        {
            Vector3 diff = transform.position - collision.gameObject.transform.position;
            direction = diff.x > 0 ? 1 : -1;
            sr.flipX = diff.x < 0;
        }
    }

    bool IsGrounded()
    {
        float distToGround = GetComponent<BoxCollider2D>().bounds.extents.y;
        RaycastHit2D floorHit = Physics2D.Raycast(transform.position, Vector2.down, distToGround + 5f);
        Debug.Log(floorHit.collider);
        return floorHit.collider != null;
    }
}
