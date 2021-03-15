using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 2.0f;
    public float jumpspeed = 5.0f;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody2D;
    private bool isGrounded;
    public Sprite jump;
    public Sprite normal;
    private Animator animator;
    public Text Scoretext;
    public int score=0;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        var x = PlayerPrefs.GetFloat("x",0.0f);
        var y = PlayerPrefs.GetFloat("y",0.0f);
        Debug.Log(x);
        Debug.Log(y);

        if(x !=0.0f && y != 0.0f)
        {
           transform.position = new Vector3(x, y, transform.position.z);
        }
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

            if (IsGrounded())
            {
                animator.enabled = true;
                animator.SetBool("Walk", true);
            }
            
            //transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
        }
        else if(h>0)
        {
            spriteRenderer.flipX = false;

            if (IsGrounded())
            {
                animator.enabled = true;
                animator.SetBool("Walk", true);
            }
            //transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        else if(h==0)
        {
            animator.SetBool("Walk", false);
            animator.enabled = false;
        }

       // if (h != 0)
           // spriteRenderer.flipX = h < 0;

        if(Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            animator.SetBool("Walk", false);
            animator.enabled = false;
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

        if (collision.gameObject.tag == "CoinBlock")
        {
            score++;
            Scoretext.text = "Score: " + score.ToString();
            Debug.Log("Score: " + score);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Base")
            isGrounded = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Big")
        {
            // Widen the object by 0.1
            transform.localScale += new Vector3(2f, 2f, 2f);
        }

        if(other.gameObject.tag =="Small")
        {
            transform.localScale -= new Vector3(2f, 2f, 2f);
        }

        if (other.gameObject.tag == "GoBack")
        {
            transform.position = new Vector3(-7, -3, 0);
        }

        if (other.gameObject.tag == "Coin")
        {
            score++;
            Scoretext.text = "Score: " + score.ToString();
            Debug.Log("Score: " + score);
        }
    }

}
