using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainController : MonoBehaviour
{ 
   int health;
    // Start is called before the first frame update
    void Start()
    {
        health =400;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(health);

        if (health <= 0)
        {

            Destroy(gameObject);
        }
    }

    public void applyDamage()
    {

        health--;
    }
    
}
