using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class boll_BlackWhite : MonoBehaviour
{
    public GameObject black;

    public GameObject white;

    

    public bool active = false;

 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.S) && active == false)
            {
                black.SetActive(false);
                white.SetActive(true);
                active = true;
            }
            else if (Input.GetKeyDown(KeyCode.S) && active == true)
            {

                black.SetActive(true);
                white.SetActive(false);
                active = false;
            }
    }

  
}
