using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActive1 : MonoBehaviour
{
    public GameObject Button1;
    public GameObject fire1;

    

    void Start()
    {
        fire1.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Button1.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Button1.SetActive(false);

    }


    void Update()
    {
        if (Button1.activeSelf && Input.GetKeyDown(KeyCode.F)&& !fire1.activeSelf)
        {
            fire1.SetActive(true);
            
        }
        
    }
}
