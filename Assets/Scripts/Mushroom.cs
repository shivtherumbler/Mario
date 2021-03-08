using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Fall")
        {
            Debug.Log("Collision has occurred");
            animator.SetBool("Mushroom", true);

        }
    }

    public void OnAnimationCompleted()
    {
        animator.SetBool("Mushroom", false);
    }

}
