using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class B3ToB2Fake : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {

        SceneManager.LoadScene("Dungeon_B2F_2");
    }

}
