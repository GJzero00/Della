using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class returnBack : MonoBehaviour
{
    public int delayTime;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("backtofront",delayTime);
    }
    void backtofront()
    {
        SceneManager.LoadScene("Dungeon_B3F");
    }
}
