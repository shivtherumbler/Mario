﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Size : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Fall")
        {
            Destroy(gameObject);
        }
    }
}
