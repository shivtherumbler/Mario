using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = -2.0f;

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       
            rb.velocity = new Vector2(1.0f * speed, rb.velocity.y);

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            speed = -speed;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

    }


}
