using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextScence : MonoBehaviour
{
    
   

    // Update is called once per frame
     void Update()
     {
        Invoke("NextScences", 2f);

     }



    void NextScences()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(1);
        }
    }
}
