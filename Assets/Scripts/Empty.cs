using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empty : MonoBehaviour
{
    public Sprite EmptySprite;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Fall")
        {
            spriteRenderer.sprite = EmptySprite;
        }
    }
}
