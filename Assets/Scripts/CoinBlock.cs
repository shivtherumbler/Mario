using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBlock : MonoBehaviour
{
    private int hit = 0;

    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Fall")
        {
            hit += 1;
            checkhit();
        }
    }

    public void checkhit()
    {
        if (hit == 6)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
