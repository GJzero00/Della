using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SneakattackAnim : MonoBehaviour
{
    public GameObject enemy;
    public float delayTime;
    public GameObject UI;
    public bool check;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        Transitions();
       
        if (enemy == null && check == true)
        {
            Invoke("Anim", delayTime);
        }
    }

   void Anim()
    {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Transitions()
    {
        if (enemy == null)
        {
            check = true;

            UI.SetActive(true);
        }
    }
}
