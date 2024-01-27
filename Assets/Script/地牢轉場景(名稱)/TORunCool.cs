using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TORunCool : MonoBehaviour
{
    public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;
    public GameObject fire4;
    public GameObject fire5;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (fire1.activeSelf && fire3.activeSelf&& fire4.activeSelf && !fire2.activeSelf && !fire5.activeSelf) 
        {
        SceneManager.LoadScene("run cool");
        }
    
    }

    
}
