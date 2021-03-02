using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2.0f;
    public float jumpspeed = 5.0f;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody2D;
    private bool isGrounded;
    public Sprite jump;
    public Sprite normal;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        //var v = Input.GetAxis("Vertical");

        rigidBody2D.velocity = new Vector2(h * speed, rigidBody2D.velocity.y);

        if(h<0)
        {
            spriteRenderer.flipX = true;
            //transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
        }
        else if(h>0)
        {
            spriteRenderer.flipX = false;
            //transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

       // if (h != 0)
           // spriteRenderer.flipX = h < 0;

        if(Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpspeed);
            spriteRenderer.sprite = jump;
        }
        
    }

    private bool IsGrounded()
    {
        //return rigidBody2D.velocity.y == 0.0f;
        return isGrounded;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Base")
            isGrounded = true;
        spriteRenderer.sprite = normal;

        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Collided with plant");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Base")
            isGrounded = false;
    }
}
