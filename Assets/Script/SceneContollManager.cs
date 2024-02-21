using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneContollManager : MonoBehaviour
{
    private int PresentScene;
    private float Timer;
    private bool UsedCheck;
    private void Update()
    {
        PresentScene = SceneManager.GetActiveScene().buildIndex;
        NextScence();
        //Debug.Log(Timer);ÀË¬d¥Î
    }


    public void NextScence()
    {

        if (UsedCheck == false)
        {
            Timer += Time.deltaTime;
        }
        
        if (PresentScene ==0 && Timer>=1.5f &&Input.anyKeyDown)
        {
            SceneManager.LoadScene(PresentScene+1);
            Timer = 0f;
            UsedCheck = true;
        }
        else
        {
            UsedCheck = false;
        }

        

    }

    public void Prologue_Skip() // Prologue Skip Button
    {
        SceneManager.LoadScene(PresentScene+1);
    }

    public void CamelDieChangeScene() //Boss Camel die and change next scene
    {
        SceneManager.LoadScene(PresentScene + 1);
    }












}
