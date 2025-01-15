using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu2 : MonoBehaviour
{
    public static GameObject gameOverPanel;
    // Start is called before the first frame update
    public static void LoadSceneByIndex(int sceneIndex) 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * sceneIndex);
        SceneManager.LoadScene("SampleScene");
    }
     void Start()
    {
        gameOverPanel.SetActive(false);
    }
   

    public static void QuitGame()
    {
        Debug.Log("Game is quitting");
        //gameOverPanel.SetActive(true);
        Application.Quit();
        SceneManager.LoadScene("GameOver");

    }
}
