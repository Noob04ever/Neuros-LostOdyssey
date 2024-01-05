using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] private Transform UpPosition;
    [SerializeField] private Transform MiddlePosition;
    [SerializeField] private Transform DownPosition;
    private bool JDown = false;
    private bool KDown = false;
    private bool bAnyButtonHold = false;
    bool bIsFalling = false;
    [SerializeField] private float FallSpeed = 8.0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        JDown = Input.GetKey(KeyCode.J);
        KDown = Input.GetKey(KeyCode.F);
        // Set Boolean Trigger for holding animation
        SetSpritePositionAndAnimation();
        if(bIsFalling)
        {
            if(transform.position.y > DownPosition.position.y)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - FallSpeed * Time.deltaTime);
            }
            else if (transform.position.y <= DownPosition.position.y)
            {
                transform.position = DownPosition.position;
            }
        }
    }

    private void SetSpritePositionAndAnimation()
    {
        if(JDown && KDown)
        {
            StartCoroutine("StartFalling");

            transform.position = MiddlePosition.position;
            bIsFalling = true;
        }
        else if (JDown)
        {
            StopCoroutine("StartFalling");
            bIsFalling = false;
            transform.position = DownPosition.position;
            animator.SetTrigger("Slash");
        }
        else if (KDown)
        {
            bIsFalling = false;
            StartCoroutine("StartFalling");
            transform.position = UpPosition.position;
            animator.SetTrigger("Stab");
        }
    }

    private IEnumerator StartFalling()
    {
        Debug.Log("FALLING CALLED");

        yield return new WaitForSeconds(0.5f);
        bIsFalling = true;

    }
}
