using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class SwitchQ : MonoBehaviour
{

    public static bool CheckSwitch = false;
    public int propreity;//B=0 W=1
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (CheckSwitch)
            {
                Black();
            }
            else
            {
                White();
            }
        }
    }
   public void Black()
    {
        propreity = 0;
        CheckSwitch = false;
    }
   public void White()
    {
        propreity = 1;
        CheckSwitch = true;
    }
}

