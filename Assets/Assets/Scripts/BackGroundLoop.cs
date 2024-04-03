using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    private float Width;
    BoxCollider2D BackCollider2D;

    private void Awake()
    {
        BackCollider2D = GetComponent<BoxCollider2D>();
        Width = BackCollider2D.size.x;
    }
    void Update()
    {
        if (transform.position.x <= -Width)
            LoopPosition();
    }
    private void LoopPosition()
    {
        Vector2 offset = new Vector2(Width * 2.0f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
