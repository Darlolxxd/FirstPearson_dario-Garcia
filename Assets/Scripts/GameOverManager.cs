using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverManager: MonoBehaviour
{
    public AudioSource buttonClickSound, endOfGame;  // Reference to the AudioSource component
  //  public GameObject gameOverUI;  // Game Over UI Panel
    public Button restartButton;   // Restart Button
    public Button quitButton;      // Quit Button

      // Reference to VidaPersonaje class
    public VidaPersonaje vidaPersonaje;

    //  void Awake()
    //  {
    //     isGameOver = true;
    //     PlaySound(endOfGame);
    //     Time.timeScale = 0f;         // Pause the game
    //  }

    // This function is called when the button is clicked
    public void ReStartGame()
    { 
        Debug.Log("GO Manager: Restarting game.");
        // Play the click sound
        PlaySound(buttonClickSound);
        Time.timeScale = 1f;    // Unpause the game
        // Load the game main scene
        SceneManager.LoadScene("SampleScene");
    }

    // This function is called when the exit button is clicked
    public void QuitGame()
    { 
        Debug.Log("GO Manager: Quitting game...");
        PlaySound(endOfGame); // Play the End Of Game sound
        Time.timeScale = 0f;  // Paused any time related execution
                          // Load the game over scene
        SceneManager.LoadScene("GameOver");
        Application.Quit();
    }

    // Function to play the sound
    private void PlaySound(AudioSource sound)
    {
        if (sound != null)
        {
            sound.Play();  // Play the sound effect
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to the event
        if (vidaPersonaje != null)
        {
            vidaPersonaje.OnPlayerDeath += QuitGame;
        }
    }

    // Unsubscribe from the event to avoid memory leaks when the object is destroyed
    private void OnDestroy()
    {
        if (vidaPersonaje != null)
        {
            vidaPersonaje.OnPlayerDeath -= QuitGame;
        }
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
