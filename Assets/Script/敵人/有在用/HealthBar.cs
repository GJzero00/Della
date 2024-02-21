using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text healthText;
    private Image healthBar;

    void Start()
    {
        GameObject bossEnemies = GameObject.FindGameObjectWithTag("Bossenemies");
        if (bossEnemies != null)
        {
            healthBar = bossEnemies.GetComponent<Image>();
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
            HealthBar healthBarComponent = healthBarObject.GetComponent<HealthBar>();
            if (healthBarComponent != null)
            {
                healthBarComponent.UpdateHealthBarInternal(currentHealth, maxHealth);
            }
        }
    }

    private void UpdateHealthBarInternal(int currentHealth, int maxHealth)
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
            healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
        }
        else
        {
            Debug.LogError("HealthBar component is not assigned!");
        }
    }
}
