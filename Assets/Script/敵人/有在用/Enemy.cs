using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public float dieTime;

    public GameObject bloodEffect;

    static public int enemyproperty;
    public int setenemyproperty;

    private PlayerHealth playerHealth;
    private Animator anim;

    private Color originalColor;
    private SpriteRenderer sr;
    public float flashTime;

    public void Start()
    {
        HealthBar.HealthMax = health;
        HealthBar.HealthCurrent = health;

        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }


    public void Update()
    {
       if(health < 0)
        {
            health = 0;
           
        }
        HealthBar.HealthCurrent = health;
        if( health == 0)
        {
            anim.SetBool("enemyDie", true);
            Invoke("Killenemy", dieTime);
        }

    }

    void Killenemy()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage, int playerproperty, int enemyproperty)
    {
        enemyproperty = setenemyproperty;
        if (playerproperty == enemyproperty)
        {
            health -= 0;
        }
        else
        {
            health -= damage;
            anim.SetBool("enemyDamage", true);
            Instantiate(bloodEffect, transform.position, Quaternion.identity);
            FlashColor(flashTime);
        }
    }
    public void NotTakeDamage(int damage)
    {
        health -= 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            if (playerHealth != null)
            {
                playerHealth.DamegePlayer(damage);
            }
        }
    }

    void FlashColor(float time)
    {
        sr.color = new Color(128,0,0,1);
        Invoke("ResetColor", time);
    }

    void ResetColor()
    {
        sr.color = originalColor;
    }
}


