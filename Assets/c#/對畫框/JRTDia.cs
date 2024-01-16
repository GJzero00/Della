using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JRTDia : MonoBehaviour
{
    public GameObject Button;
    public GameObject fire;

    public bool active = false;

     void Start()
    {
        fire.SetActive(false);
      
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        Button.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Button.SetActive(false);

    }


    void Update()
    {
        if (Button.activeSelf && Input.GetKeyDown(KeyCode.F) && active == false)
        {
          fire.SetActive(true);
            active = true;
        }
        else if (Button.activeSelf && Input.GetKeyDown(KeyCode.F) && active == true)
        {
            fire.SetActive(!fire.activeSelf);
            active =false;
        }
    }
    
}
