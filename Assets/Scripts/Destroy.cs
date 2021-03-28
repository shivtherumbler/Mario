using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private AudioSource audios;
    public Sprite squash;
    public GameObject villain;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audios = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (villain.GetComponent<BoxCollider2D>().enabled == false)
        {
            villain.GetComponent<SpriteRenderer>().sprite = squash;
            Destroy(gameObject.transform.parent.gameObject, 1.0f);
        }
    }

    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            
            villain.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}
