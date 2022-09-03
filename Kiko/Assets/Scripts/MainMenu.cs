using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour //ATTACH THIS SCRIPT TO CANVAS OBJECT IN MAIN MENU SCENE
{
    public int i = 1;

    public void ExitButton() {
        Application.Quit();
        Debug.Log("Game Exited");
    }


    public void StartGame() {
        SceneManager.LoadScene("Day " + i);
    }
    public void ReturnMainMenu(){
        SceneManager.LoadScene("Main Menu");
    }

}
