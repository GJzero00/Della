using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public float dieTime;
    public GameObject bloodEffect;
    public int enemyProperty; // Assuming you set this in the Inspector

    private PlayerHealth playerHealth;
    private Animator anim;
    private SpriteRenderer sr;
    private Color originalColor;
    public float flashTime;

    public void Start()
    {
        HealthBar.UpdateHealthBar(health, health);
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

    public void TakeDamage(int damage, int playerProperty, int enemyroperty)
    {
        if (playerProperty != enemyProperty)
        {
            health -= damage;
            HealthBar.UpdateHealthBar(health, health);
            anim.SetBool("enemyDamage", true);
            Instantiate(bloodEffect, transform.position, Quaternion.identity);
            FlashColor(flashTime);
            // Add other logic for taking damage, like animation etc.
        }
    }

    private void Die()
    {
        if(GameObject.FindWithTag("Bossenemies") && GameObject.Find("camel"))
        {
            Debug.Log("camel die");

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


