using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private float Length, StartPos;
    public float ParallaxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position.x;
        Length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    private void FixedUpdate()
    {

        transform.position -= new Vector3(ParallaxSpeed * Time.fixedDeltaTime, 0, 0);
        if (transform.position.x > StartPos + Length)
        {
            transform.position = new Vector3(StartPos, 0, 0);
        }
        else if (transform.position.x < StartPos - Length)
        {
            transform.position = new Vector3(StartPos, 0, 0);
        }
       
    }
}
