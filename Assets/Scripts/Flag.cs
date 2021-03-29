using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    private int i;

    void Start()
    {
        i = 0;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(i==0)
            {
                Debug.Log("Collision has occurred");
                animator.SetBool("Flag", true);
                audioSource.Play();
                i++;
            }
        }
    }

    public void OnAnimationCompleted()
    {
        animator.SetBool("Flag", false);
    }
}
