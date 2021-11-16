
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
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void Menu()
    {

        Debug.Log("Go to menu");
    }


}
