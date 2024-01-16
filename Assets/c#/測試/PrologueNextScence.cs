using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class PrologueNextScence : MonoBehaviour
{
    public Animator anim;
   void NextScence()
    {
        
        SceneManager.LoadScene(5);

    }

    // Update is called once per frame
    void Update()
    {
        Invoke("NextScence", 20f);
    }
}
