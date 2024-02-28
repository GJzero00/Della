using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class B3TOB2 : MonoBehaviour
{
    // Start is called before the first frame update
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("Dungeon_B2F");
    }
}
