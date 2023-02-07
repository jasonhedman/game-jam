using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeapHitbox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), LeapHitbox.GetComponent<Collider2D>());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mouse")) {
            Destroy(collision.gameObject);
        }
    }
}
