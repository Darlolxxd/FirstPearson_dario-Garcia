using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu2 : MonoBehaviour
{
    public AudioSource buttonClickSound, startOfGame;  // Reference to the AudioSource component
  ///  public GameObject gameStartUI;  // Game Start UI Panel
    public Button restartButton;   // Restart Button
    public Button quitButton;      // Quit Button

    private bool isGameOver = false;


    void Awake()
        {
            isGameOver = false;
            PlaySound(startOfGame);
            Time.timeScale = 1f;         // Resume the timeline
        }

        // This function is called when the button is clicked
        public void StartingTheGame()
        {
        // Play the click sound
            PlaySound(buttonClickSound);
            Debug.Log("MainMenu2: Starting game.");
            Time.timeScale = 1f;    // Unpause the game
           // Load the game main scene
            SceneManager.LoadScene("SampleScene");
        }

        // This function is called when the exit button is clicked
        public void QuitGame()
        {
        // Load the game over scene
            PlaySound(buttonClickSound);
            Debug.Log("MainMenu2: Quitting game...");
            SceneManager.LoadScene("GameOver");
        //   Time.timeScale = 0f;
        //   Application.Quit();
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
      ///  gameStartUI.SetActive(true);
    }
   
}
