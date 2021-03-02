using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RetryButtonClick()
    {
        Debug.Log("Retry");

        SceneManager.LoadScene("SampleScene");
    }

    public void StartButtonClick()
    {
        Debug.Log("Start Game");
        
        SceneManager.LoadScene("SampleScene");
    }
}
