using UnityEngine;
using System.Collections;

public class CharacterAnimation : MonoBehaviour
{
    protected SpriteRenderer characterRenderer;

    public Sprite[] jumpFrames;

    public Sprite[] landFrames;

    public Sprite[] walkFrames;
    int walkFrame = 0;

    public Sprite[] airFrames;

    public float walkFPS = 10;
    public float jumpFPS = 10;
    public float landFPS = 10;
    public float airFPS = 10;

    public KeyCode jumpKey;

    Coroutine walkAnimation;

    // Start is called before the first frame update
    void Start()
    {
        characterRenderer = GetComponent<SpriteRenderer>();
        walkAnimation = StartCoroutine(AnimateWalk());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            if (IsGrounded()) StartCoroutine(AnimateJump());
            else StartCoroutine(AnimateAir());  
        }
    }

    protected IEnumerator AnimateWalk()
    {
        while (true)
        {
            characterRenderer.sprite = walkFrames[walkFrame];
            walkFrame = (walkFrame + 1) % walkFrames.Length;
            yield return new WaitForSeconds(1 / walkFPS);
        }
    }

    protected IEnumerator AnimateJump()
    {
        StopCoroutine(walkAnimation);
        for (int i = 0; i < jumpFrames.Length; i++)
        {
            characterRenderer.sprite = jumpFrames[i];
            yield return new WaitForSeconds(1 / jumpFPS);
        }
        walkAnimation = StartCoroutine(AnimateWalk());
    }

    protected IEnumerator AnimateAir()
    {
        StopCoroutine(walkAnimation);
        for (int i = 0; i < airFrames.Length; i++)
        {
            characterRenderer.sprite = airFrames[i];
            yield return new WaitForSeconds(1 / airFPS);
        }
        walkAnimation = StartCoroutine(AnimateWalk());
    }

    bool IsGrounded()
    {
        float distToGround = GetComponent<BoxCollider2D>().bounds.extents.y;
        RaycastHit2D floorHit = Physics2D.Raycast(transform.position, Vector2.down, distToGround + 0.1f);
        Debug.Log(floorHit.collider);
        return floorHit.collider != null;
    }
}

