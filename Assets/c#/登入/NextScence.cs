using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextScence : MonoBehaviour
{


    public Text mytext;
    public Image myImage;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("showHide", 0.5f, 0.5f);
    }

    void NextScences()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(1);
        }
    }


    void showHide()
    {

        if (mytext.text == "")
        { //¦pªG mytext¤º®e¬OªÅªº

            mytext.text = "°´æIßMÈëß[‘ò...."; //±N mytext¤º®e§ïÅÜ
        }
        else
        { //§_«h

            mytext.text = ""; //±N mytext¤º®e§ï¦¨ªÅªº

        }

    }
    // Update is called once per frame
    void Update()
    {
        Invoke("NextScences", 2f);

    }
}
