using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform Plant;
    void Start()
    {
        Plant = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
