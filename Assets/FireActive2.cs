using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActive2 : MonoBehaviour
{
    public GameObject Button2;
    public GameObject fire2;

   

    void Start()
    {
        fire2.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Button2.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Button2.SetActive(false);

    }


    void Update()
    {
        if (Button2.activeSelf && Input.GetKeyDown(KeyCode.F)&& !fire2.activeSelf)
        {
            fire2.SetActive(true);
            
        }
       
    }
}
