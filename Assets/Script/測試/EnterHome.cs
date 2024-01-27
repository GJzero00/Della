using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterHome : MonoBehaviour
{
 

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
            SceneManager.LoadScene(7);
        
    }
    
}
