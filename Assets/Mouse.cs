using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mouse : MonoBehaviour
{
    public float starting_speed = 5;
    internal float speed;
    internal float direction;
    public float jump_height = 10;

    internal Rigidbody2D rb;

    internal bool grounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = starting_speed;
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float x_vel = rb.velocity.x;
        x_vel = speed * direction;
        rb.velocity = new Vector3(x_vel, rb.velocity.y, 0);

        if ((Mathf.Abs(speed)) > starting_speed)
        {
            speed -= Time.deltaTime;
            speed = Mathf.Min(starting_speed * 2f, speed);
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            //Vector3 ray_start = new Vector3(rb.position.x, rb.position.y - , 0);
            //RaycastHit2D floor = Physics2D.Raycast(ray_start, Vector2.down, 0.2f);

            if (grounded)
            {
                grounded = false;
                rb.velocity = new Vector3(rb.velocity.x, jump_height, 0);
            }
            else
            {
                speed += 1;
                direction *= -1f;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stage"))
        {
            grounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stage"))
        {
            grounded = true;
        }
    }
}

