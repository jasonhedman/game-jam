using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour
{

    public float speed;
    public float offset;
    internal float movement_clock;

    internal Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        movement_clock = offset;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement_clock += Time.deltaTime;

        if (movement_clock < 2)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
        else if (movement_clock < 5)
        {
            rb.velocity = new Vector3(0, speed, 0);
        }
        else if (movement_clock < 7)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
        else if (movement_clock < 10)
        {
            rb.velocity = new Vector3(0, speed * -1, 0);
        }
        else movement_clock = 0;
    }
}
