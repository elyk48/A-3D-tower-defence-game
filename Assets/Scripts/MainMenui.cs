using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenui : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void Play()
    {
        Debug.Log("Play");
        SceneManager.LoadScene("Assets/Scenes/GameScene.unity");
    }

    // Update is called once per frame
    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
    public void Settings()
    {
        Debug.Log("Settings");
    }
}
