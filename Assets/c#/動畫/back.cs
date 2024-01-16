using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour
{
    public int delayTime;

    void Start()
    {
        
    }

 
    void Update()
    {
        Invoke("backtofront", delayTime);
    }
    void backtofront()
    {
        SceneManager.LoadScene("market");
    }
}
