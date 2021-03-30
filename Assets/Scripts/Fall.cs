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
        Destroy(GameObject.Find("Canvas1"));
        SceneManager.LoadScene("Menu");
    }

    public void StartButtonClick()
    {
        Debug.Log("Start Game");
        Destroy(GameObject.Find("Canvas1"));
        PlayerPrefs.DeleteKey("x");
        PlayerPrefs.DeleteKey("y");
        Time.timeScale = 1;
        TimeLeft.timeLeft = 500f;
        SceneManager.LoadScene("Story");
    }

    public void RestartButtonClick()
    {
        Debug.Log("Restart Game");
        Destroy(GameObject.Find("Canvas1"));
        Time.timeScale = 1;
        TimeLeft.timeLeft = 500f;
        SceneManager.LoadScene("SampleScene");
    }

    public void MenuButtonClick()
    {
        Debug.Log("Menu Screen");
        Destroy(GameObject.Find("Canvas1"));
        SceneManager.LoadScene("Menu");
    }

    public void NextButtonClick()
    {
        Debug.Log("Instructions Screen");
        Destroy(GameObject.Find("Canvas1"));
        SceneManager.LoadScene("Instructions");
    }

}
