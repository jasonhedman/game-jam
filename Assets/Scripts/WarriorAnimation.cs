using UnityEngine;
using System.Collections;

public class WarriorAnimation: MonoBehaviour
{
    SpriteRenderer warriorRenderer;

    public Sprite[] jumpFrames;

    public Sprite[] swingFrames;

    public Sprite[] walkFrames;
    int walkFrame = 0;

    float framesPerSecond = 10;

    float swingFPS = 20;

    Coroutine walkAnimation;

    // Start is called before the first frame update
    void Start()
    {
        warriorRenderer = GetComponent<SpriteRenderer>();
        walkAnimation = StartCoroutine(AnimateWalk());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            StartCoroutine(AnimateSwing());
        }
    }

    IEnumerator AnimateJump()
    {
        for (int i = 0; i < jumpFrames.Length; i++)
        {
            warriorRenderer.sprite = jumpFrames[i];
            yield return new WaitForSeconds(1 / framesPerSecond);
        }
    }

    IEnumerator AnimateWalk()
    {
        while (true)
        {
            // set the sprite
            warriorRenderer.sprite = walkFrames[walkFrame];
            // update the index
            walkFrame = (walkFrame + 1) % walkFrames.Length;
            // wait for next iteration
            yield return new WaitForSeconds(1 / framesPerSecond);
        }
    }

    IEnumerator AnimateSwing()
    {
        StopCoroutine(walkAnimation);
        for(int i = 0; i < swingFrames.Length; i++)
        {
            warriorRenderer.sprite = swingFrames[i];
            yield return new WaitForSeconds(1 / swingFPS);
        }
        StartCoroutine(AnimateWalk());
    }


}

