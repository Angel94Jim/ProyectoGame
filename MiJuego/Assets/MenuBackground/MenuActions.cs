using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
     public void PlayGame()
     {
         SceneManager.LoadScene("Game");
     }

     public void Settings()
     {
         SceneManager.LoadScene("SettingsMenu");
     }

     public void GoToMainMenu()
     {
         SceneManager.LoadScene("MainMenu");
     }

     public void ExitGame()
     {
         Application.Quit();
     }
        
}
