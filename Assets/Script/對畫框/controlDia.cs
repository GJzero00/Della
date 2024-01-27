using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlDia : MonoBehaviour
{

    public GameObject Dia;
    public GameObject tri;

   

    public bool check = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) &&(check == true))
        {
            Dia.SetActive(true);
            tri.SetActive(false);
            
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
         check = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Dia.SetActive(false);
        check = false;
        tri.SetActive(true);
        
    }
}


