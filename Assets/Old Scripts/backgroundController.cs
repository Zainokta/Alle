using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundController : MonoBehaviour {
    public float speed;
    BoxCollider2D groundCollider;
    float groundHorizontalLength;

    private void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
    }
    private void Update()
    {
        transform.Translate(new Vector2(-speed * Time.deltaTime, 0));

        if(transform.position.x < - groundHorizontalLength - 8f)
        {
            RepositionBackground();
        }
    }
    void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLength * 3f - 0.15f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
