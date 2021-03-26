using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 2.0f;
    public float jumpspeed = 5.0f;
    private int height = 0;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody2D;
    private bool isGrounded;
    public Sprite jump;
    public Sprite jump1;
    public Sprite normal;
    public Sprite normal1;
    public Sprite strong;
    public Sprite jumpbig;
    private Animator animator;
    public Text Scoretext;
    public Text Cointext;
    public int score=0;
    public int coins = 0;
    private AudioSource audios;
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
    public AudioClip sound5;
    public AudioClip sound6;
    public AudioClip sound7;
    public AudioSource backmusic;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audios = GetComponent<AudioSource>();
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
                if (height <= 1)
                {
                    animator.SetBool("Walk", true);
                    animator.SetBool("Big Walk", false);
                }
                else if (height >= 2)
                {
                    animator.SetBool("Big Walk", true);
                    animator.SetBool("Walk", false);
                }
            }
            
            //transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
        }
        else if(h>0)
        {
            spriteRenderer.flipX = false;

            if (IsGrounded())
            {
                animator.enabled = true;
                if (height <= 1)
                {
                    animator.SetBool("Walk", true);
                    animator.SetBool("Big Walk", false);
                }
                else if (height >= 2)
                {
                    animator.SetBool("Big Walk", true);
                    animator.SetBool("Walk", false);
                }
            }
            //transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        else if(h==0)
        {
            if (height <= 1)
            {
                animator.SetBool("Walk", false);
                animator.SetBool("Big Walk", true);
            }
            else if(height >= 2)
            {
                animator.SetBool("Big Walk", false);
                animator.SetBool("Walk", true);
            }
            animator.enabled = false;
        }

       // if (h != 0)
           // spriteRenderer.flipX = h < 0;

        if(Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            if (height <= 1)
            {
                animator.SetBool("Walk", false);
                animator.SetBool("Big Walk", true);
            }
            else if (height >= 2)
            {
                animator.SetBool("Big Walk", false);
                animator.SetBool("Walk", true);
            }
            animator.enabled = false;
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpspeed);
            if(height <= 1)
            {
                spriteRenderer.sprite = jump1;
            }
            else if(height >= 2)
            {
                spriteRenderer.sprite = jumpbig;
            }
                
            
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                audios.clip = sound5;
                audios.Play();
                backmusic.Pause();
            }
            else
            {
                Time.timeScale = 1;
                audios.clip = sound5;
                audios.Play();
                backmusic.Play();
            }
            
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!backmusic.isPlaying)
            {
                backmusic.Play();
            }
            else
            {
                backmusic.Pause();
            }

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
        
        if(height <= 1)
        {
            spriteRenderer.sprite = normal1;
        }
        
        else if(height >= 2)
        {
            spriteRenderer.sprite = strong;
        }
            
        


        if (collision.gameObject.tag == "CoinBlock")
        {
            score++;
            Scoretext.text = "Score: " + score.ToString();
            Debug.Log("Score: " + score);
            coins++;
            Cointext.text = "X " + coins.ToString();
            Debug.Log("Coins: " + coins);
            audios.clip = sound7;
            audios.Play();
        }

        if (collision.gameObject.tag == "Finish")
        {
            audios.clip = sound3;
            audios.Play();
            backmusic.enabled = false;
        }

        if (collision.gameObject.tag == "enemy")
        {
            score++;
            Scoretext.text = "Score: " + score.ToString();
            Debug.Log("Score: " + score);
            audios.clip = sound4;
            audios.Play();
        }

        if (collision.gameObject.tag == "brick")
        {
            score++;
            Scoretext.text = "Score: " + score.ToString();
            Debug.Log("Score: " + score);
            audios.clip = sound6;
            audios.Play();
        }

        if (collision.gameObject.tag == "block")
        {
            audios.clip = sound7;
            audios.Play();
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Base")
            isGrounded = false;

        if (collision.gameObject.tag == "deadly")
        {
            height -= 1;
            checkheight();
            audios.clip = sound4;
            audios.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Big")
        {
            
            height += 1;
            checkheight();
            score++;
            Scoretext.text = "Score: " + score.ToString();
            Debug.Log("Score: " + score);
            audios.clip = sound2;
            audios.Play();

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
            coins++;
            Cointext.text = "X " + coins.ToString();
            Debug.Log("Coins: " + coins);
            audios.clip = sound1;
            audios.Play();
        }
    }

    public void checkheight()
    {
        if(height <= -1)
        {
            SceneManager.LoadScene("GameOver");
        }

        if(height <= 0)
        {
            transform.localScale = new Vector3(5f, 5f, 5f);
            normal = normal1;
            jump = jump1;
            GetComponent<BoxCollider2D>().size = new Vector2(0.12f, 0.16f);
        }

        if (height == 1)
        {
            normal = normal1;
            jump = jump1;
             transform.localScale += new Vector3(1.5f, 1.5f, 1.5f);
             GetComponent<BoxCollider2D>().size = new Vector2(0.12f, 0.16f);

        }

        if (height == 2)
        {
            normal = strong;
            jump = jumpbig;
            transform.localScale -= new Vector3(1.5f, 1.5f, 1.5f);
            GetComponent<BoxCollider2D>().size = new Vector2(0.12f, 0.31f);
            Debug.Log("Height=2");
        }
    }
}
