using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public float speed = 1.0f;

    private Rigidbody2D rb;
    private Animator animator;
    private AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision has occurred");
            animator.SetBool("Mushroom", true);
            audioSource.Play();
            Invoke("OnAnimationCompleted", 2);
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            speed = -speed;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

    }

    void LateUpdate()
    {

        rb.velocity = new Vector2(1.0f * speed, rb.velocity.y);

    }

    public void OnAnimationCompleted()
    {
        animator.SetBool("Mushroom", false);
        animator.enabled = false;

    }

}
