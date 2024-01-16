using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireactive3 : MonoBehaviour
{
    public GameObject Button3;
    public GameObject fire3;

   

    void Start()
    {
        fire3.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Button3.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Button3.SetActive(false);

    }


    void Update()
    {
        if (Button3.activeSelf && Input.GetKeyDown(KeyCode.F) && !fire3.activeSelf)
        {
            fire3.SetActive(true);
            
        }
        
    }
}
