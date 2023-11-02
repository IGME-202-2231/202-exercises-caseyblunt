using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    // Initialize the spriteRenderer reference
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public float MinX
    {
        get { return spriteRenderer.bounds.min.x; }
    }

    public float MaxX
    {
        get { return spriteRenderer.bounds.max.x; }
    }

    public float MinY
    {
        get { return spriteRenderer.bounds.min.y; }
    }

    public float MaxY
    {
        get { return spriteRenderer.bounds.max.y; }
    }

    public Vector2 SpriteSize
    {
        get { return spriteRenderer.bounds.size; }
    }
}
