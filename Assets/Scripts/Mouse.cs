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
    }

    protected override void AirMove()
    {
        speed += 1;
        direction *= -1f;
        sr.flipX = !sr.flipX;
    }
}

