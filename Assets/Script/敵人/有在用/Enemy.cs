using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int damage;
    public float dieTime;
    public GameObject bloodEffect;
    public int enemyProperty; // Assuming you set this in the Inspector

    private PlayerHealth playerHealth;
    private Animator anim;
    private SpriteRenderer sr;
    private Color originalColor;
    public float flashTime;
    private SceneContollManager SceneContoller;




    public void Start()
    {
        HealthBar.UpdateHealthBar(health, maxHealth);
        SceneContoller = GameObject.Find("SceneContoller").GetComponent<SceneContollManager>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        
    }

    public void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damage, int playerProperty)
    {
        if (playerProperty != enemyProperty)
        {
            health -= damage;
            HealthBar.UpdateHealthBar(health, maxHealth);
            anim.SetBool("enemyDamage", true);
            Instantiate(bloodEffect, transform.position, Quaternion.identity);
            FlashColor(flashTime);
            // Add other logic for taking damage, like animation etc.
        }
    }

    private void Die()
    {
        if(GameObject.FindWithTag("Bossenemies") )
        {
            if (GameObject.Find("camel"))
            {
                SceneContoller.CamelDieChangeScene();
                Debug.Log("camel die");
            }
        }
        

        Destroy(gameObject, dieTime);
    }


    private void FlashColor(float time)
    {
        sr.color = new Color(0.5f, 0f, 0f, 1f); // Red
        Invoke("ResetColor", time);
    }

    private void ResetColor()
    {
        sr.color = originalColor;
    }
}


