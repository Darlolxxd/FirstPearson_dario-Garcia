using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false; // To track the pause
    public GameObject pauseMenu; // Reference to the pause menu UI (optional)
    void Update()
    { // Check if the Escape key is pressed
     if (Input.GetKeyDown(KeyCode.Escape)) 
      { 
            TogglePause(); // Toggle the pause state
          
            
      }
    }
    
    void TogglePause() 
    { isPaused = !isPaused;
        // Toggle the pause state // Pause or unpause the game by setting Time.timeScale
     if (isPaused)
        
     { 
       Time.timeScale = 0f; 
            // Pause the game (stops all time-based actions)
        //if (pauseMenu != null) pauseMenu.SetActive(true);
            // Show pause menu if it's assigned
     }
      else
      { Time.timeScale = 1f; 
           // Unpause the game (resume normal speed)
       // if (pauseMenu != null) pauseMenu.SetActive(false); 
        // Hide pause menu if it's assigned }
      } 
    } 

    
}
