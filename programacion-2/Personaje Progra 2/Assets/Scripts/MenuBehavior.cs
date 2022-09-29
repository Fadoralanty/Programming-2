using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour
{
   
     public void ExitGame()
     {
        Application.Quit();
     }

    public void PlayGame()
    {
        SceneManager.LoadScene("Nivel 1");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("Controles");
    }

    public void ExitHowToPlay()
    {
       SceneManager.LoadScene("Menu");
    }

}
