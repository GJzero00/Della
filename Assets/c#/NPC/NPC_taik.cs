using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_taik : MonoBehaviour
{
    private Animator anim;

    public bool check = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && check == true)
        {
            anim.SetBool("talk", true);
        }
        else
        {
            anim.SetBool("talk", false);
        }
     }
    void OnTriggerEnter2D(Collider2D other)
    {
        check = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        check = false;
    }
}
