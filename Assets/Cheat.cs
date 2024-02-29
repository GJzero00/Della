using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheat : MonoBehaviour
{
    // Start is called before the first frame update
    private int PresentScene;
    private void Start()
    {
        PresentScene = SceneManager.GetActiveScene().buildIndex;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) { SceneManager.LoadScene(PresentScene + 1);  }

    }
}
