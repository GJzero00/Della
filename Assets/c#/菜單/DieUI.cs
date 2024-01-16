using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DieUI : MonoBehaviour
{
    public GameObject player;

    public GameObject dieUI;

   


    void Update()
    {
        DiePause();
    }

    void DiePause()
    {
        if (player == null)
        {
            dieUI.SetActive(true);
            
        }
        else
        {
            dieUI.SetActive(false);
  
        }
    }
}
