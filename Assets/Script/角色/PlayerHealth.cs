using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public float dieTime;

    
    private Animator anim;
    private Playercontroller playercontroller;
    

    public void Start()
    {
        anim = GetComponent<Animator>();
        playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<Playercontroller>();
    }

   
    public void DamagePlayer(int damage)
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
   
   
}
