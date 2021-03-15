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

        SceneManager.LoadScene("Menu");
    }

    public void StartButtonClick()
    {
        Debug.Log("Start Game");

        PlayerPrefs.DeleteKey("x");
        PlayerPrefs.DeleteKey("y");
        SceneManager.LoadScene("SampleScene");
    }

    public void RestartButtonClick()
    {
        Debug.Log("Restart Game");

        SceneManager.LoadScene("SampleScene");
    }

    public void MenuButtonClick()
    {
        Debug.Log("Menu Screen");

        SceneManager.LoadScene("Menu");
    }

}
