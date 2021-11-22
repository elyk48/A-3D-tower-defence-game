using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrainController : MonoBehaviour
{
    public GameObject Ui;
    public Image healthBar;
    int health=250;
    private float Starthealth;
    // Start is called before the first frame update
    void Start()
    {//initializing the starting health
        Starthealth =health;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(health);

        if (health <= 0)
        { //calling the game over menu
            GameOverMenu();
            Destroy(gameObject);
        }
    }
    //a function to apply damage to the brain and affect the healthbar
    public void applyDamage()
    {

        health--;
        //Image mta el healthbar tonkes bechwaya bchwaya 
        healthBar.fillAmount = health / Starthealth;
    }

    public void GameOverMenu()
    {
        //if the panel is active it makes it not active and viseversa
        Ui.SetActive(!Ui.activeSelf);
        //testing if the ui is active
        if (Ui.activeSelf)
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
}
