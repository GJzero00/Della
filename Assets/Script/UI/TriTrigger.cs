using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriTrigger : MonoBehaviour
{
    public GameObject Tri;

   

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Tri.SetActive(true);
           
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            Tri.SetActive(false);
        }
    }
}
