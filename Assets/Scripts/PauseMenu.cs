
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //ref for the Pause menu game object
    public GameObject UI;
    void Update()
    {
        //testing if the player pressed the escape button or the "p" button
        if( Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            //calling the pause function
            Pause();

        }
    }

    //function that sets the pause menu panel active and ! active 
   public void Pause()
    {
        //if the panel is active it makes it not active and viseversa
        UI.SetActive(!UI.activeSelf);
        //testing if the ui is active
        if (UI.activeSelf)
        {
            //freezing the game by setting timescale =0f;
            Time.timeScale = 0f;
        }
        else
        {
            //resetting the game to normal speed
            Time.timeScale = 1f;
        }
    }


    public void Continue()
    {


    }
    //retry button function
    public void Retry()
    {  //trajaaa l wakt normal 
        Time.timeScale = 1f;
        //load scene using build Index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    //go to Main Menu button
    public void Menu()
    {
        //load the scene with name
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }


}
