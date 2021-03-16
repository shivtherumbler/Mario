using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroy : MonoBehaviour
{
    private int hit = 0;
   
    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            hit += 1;
            checkhit();
        }
    }

    public void checkhit()
    {
        if (hit == 2)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
