﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlock : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Fall")
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }

    
}
