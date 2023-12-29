using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMover : MonoBehaviour
{
    // Create Mover the parallax effect without the camera moving, Rhythm game doesn't want camera to move
    private float StartPos, Length;
    [SerializeField] private float speed = 2.0f; 
    [SerializeField] private SpriteRenderer ParallexSprite;

    void Start()
    {
        StartPos = transform.position.x;
        Length = ParallexSprite.bounds.size.x;

    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(speed * Time.fixedDeltaTime, 0, 0);
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
