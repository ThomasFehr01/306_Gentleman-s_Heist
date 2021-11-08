using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame(){
        Debug.Log("PLAY");
        // Switches to the first Scene here
        SceneManager.LoadScene("Milestone2");
    }

    public void QuitGame(){
        // Stops the Game -> only works once it's built
        Debug.Log("QUIT");
        Application.Quit();
    }
}
