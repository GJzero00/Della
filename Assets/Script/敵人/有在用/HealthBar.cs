using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    private Image healthBar;

    void Start()
    {
        GameObject bossEnemies = GameObject.FindGameObjectWithTag("Bossenemies");
        if (bossEnemies != null)
        {
            //Debug.Log(bossEnemies.name); confirm that I did get GameObject.camel
            healthBar = bossEnemies.GetComponentInChildren<Image>();
            Debug.Log(healthBar.name);
            if (healthBar == null)
            {
                Debug.LogError("HealthBar component not found on Bossenemies GameObject!");
            }
        }
        else
        {
            Debug.LogError("Bossenemies GameObject not found!");
        }
    }

    public static void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        GameObject healthBarObject = GameObject.FindGameObjectWithTag("HealthBar");
        if (healthBarObject != null)
        {
            Debug.Log(healthBarObject.name);// check is it HpBar
            Debug.Log(currentHealth + "," + maxHealth);//check what is in currentHealth and maxHealth
            HealthBar healthBarComponent = healthBarObject.GetComponent<HealthBar>();
            if (healthBarComponent != null)
            {
                Debug.Log(" Found Component");
                healthBarComponent.UpdateHealthBarInternal(currentHealth, maxHealth);
            }
        }
    }

    private void UpdateHealthBarInternal(int currentHealth, int maxHealth)
    {
        if (healthBar != null)
        {
            
            healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
            
        }
        else
        {
            Debug.LogError("HealthBar component is not assigned!");
        }
    }
}
