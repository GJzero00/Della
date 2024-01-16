using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public float dieTime;

    private Rigidbody2D rb;
    private Animator anim;
    private Playercontroller playercontroller;
    private float speed;

    public void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<Playercontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        Black();
        White();
    }
    public void DamegePlayer(int damage)
    { 
        health -= damage;
    
        if(health == 0)
        {
            anim.SetTrigger("Die");
            Invoke("KillPlayer", dieTime);
            StopDieMove();
        }
    }
    void KillPlayer()
    {
        Destroy(gameObject);
    }

    void StopDieMove()
    {
        playercontroller.enabled = false;
    }
   
   void Black()
    {
        anim.SetBool("Bdle", true);
        anim.SetBool("Wdle", false);


    }
   void White()
    {
        anim.SetBool("Wdle", true);
        anim.SetBool("Bdle", false);


    }
}
