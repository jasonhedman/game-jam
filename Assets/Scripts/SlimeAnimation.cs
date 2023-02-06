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

    Coroutine walkAnimation;

    // Start is called before the first frame update
    void Start()
    {
        slimeRenderer = GetComponent<SpriteRenderer>();
        walkAnimation = StartCoroutine(AnimateWalk());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine(walkAnimation);
            //StartCoroutine(AnimateJump());
            //StartCoroutine(AnimateWalk());
        }
    }

    IEnumerator AnimateJump()
    {
        for(int i = 0; i < jumpFrames.Length; i++)
        {
            slimeRenderer.sprite = jumpFrames[i];
            yield return new WaitForSeconds(1 / framesPerSecond);
        }
    }

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
