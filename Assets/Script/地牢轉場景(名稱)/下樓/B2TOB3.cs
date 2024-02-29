using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class B2TOB3 : MonoBehaviour
{
    // Start is called before the first frame update
  
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("Dungeon_B3F_2");
    }
}
