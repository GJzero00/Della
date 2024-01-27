using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFire :MonoBehaviour
{

    public GameObject Button;
    
    
    public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Controlf();
    }


    void Controlf()
    {

        if (!fire1.activeSelf &&Input.GetKeyDown(KeyCode.F)&&Button.activeSelf)
        {
            if (fire2.activeSelf==false)
            {
                fire2.SetActive(true);
            }
            if (fire2.activeSelf)
            {
                fire2.SetActive(false);
            }
        }
       /*if (!fire2.activeSelf && Input.GetKeyDown(KeyCode.F) && Button.activeSelf)
        {
            if (fire1.activeSelf)
            {
                fire1.SetActive(false);
            }
            if (fire3.activeSelf)
            {
                fire3.SetActive(false);
            }


        }
       if (!fire3.activeSelf && Input.GetKeyDown(KeyCode.F) && Button.activeSelf)
        {
            if (!fire2.activeSelf)
            {
                fire2.SetActive(true);
            }
            if (fire2.activeSelf)
            {
                fire2.SetActive(false);
            }
        }*/ 
        



    }
}
