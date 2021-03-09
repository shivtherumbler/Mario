using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    private int hit = 0;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fall")
        {
            hit += 1;
            checkhit();

        }
    }
        public void checkhit()
        {

        if(hit == 1)
        {
            
            Player.transform.localScale -= new Vector3(2f, 2f, 2f);
            
        }

            if (hit == 2)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
}
