using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision has occurred");
            animator.SetBool("Flag", true);
            audioSource.Play();
        }
    }

    public void OnAnimationCompleted()
    {
        animator.SetBool("Flag", false);
    }
}
