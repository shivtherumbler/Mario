using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Sprite DefaultSprite;
    public Sprite JumpSprite;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key is pressed");
            spriteRenderer.sprite = JumpSprite;
        }
    }

    public void OnAnimationCompleted()
    {
        spriteRenderer.sprite = DefaultSprite;
    }
}
