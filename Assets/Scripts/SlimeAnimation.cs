using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnimation : MonoBehaviour
{

    SpriteRenderer slimeRenderer;

    public Sprite[] jumpFrames;

    public Sprite[] walkFrames;
    int walkFrame = 0;

    float framesPerSecond = 10;

    // Start is called before the first frame update
    void Start()
    {
        slimeRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(AnimateWalk());
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    if()
    //}

    IEnumerator AnimateWalk()
    {
        while(true)
        {
            // set the sprite
            slimeRenderer.sprite = walkFrames[walkFrame];
            // update the index
            walkFrame = (walkFrame + 1) % walkFrames.Length;
            // wait for next iteration
            yield return new WaitForSeconds(1 / framesPerSecond);
        }
    }
}
