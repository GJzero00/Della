using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TriggerAnim : MonoBehaviour
{
    public GameObject trigger;
    public GameObject UI;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        UI.SetActive(true);
        Invoke("Next", 3);
    }
    void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
