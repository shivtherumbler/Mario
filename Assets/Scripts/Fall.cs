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
        Time.timeScale = 1;
        TimeLeft.timeLeft = 200f;
        SceneManager.LoadScene("Story");
    }

    public void RestartButtonClick()
    {
        Debug.Log("Restart Game");
        Time.timeScale = 1;
        TimeLeft.timeLeft = 200f;
        SceneManager.LoadScene("SampleScene");
    }

    public void MenuButtonClick()
    {
        Debug.Log("Menu Screen");

        SceneManager.LoadScene("Menu");
    }

    public void NextButtonClick()
    {
        Debug.Log("Instructions Screen");

        SceneManager.LoadScene("Instructions");
    }

}
