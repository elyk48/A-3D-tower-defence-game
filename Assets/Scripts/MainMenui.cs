using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenui : MonoBehaviour
{
    
    // Start is called before the first frame update
    //a function that redirects you to the game scene 
    //used by the button play
    /// <summary>
    /// 
    /// </summary>
    public void Play()
    {
        Debug.Log("Play");
        SceneManager.LoadScene("Assets/Scenes/GameScene.unity");
    }

    // Update is called once per frame
    //Function for the exit button
    public void Exit()
    {//test
        Debug.Log("Exit");
        Application.Quit();
    }
    //Function for the settings button
    public void Settings()
    {//test
        Debug.Log("Settings");
    }
}
