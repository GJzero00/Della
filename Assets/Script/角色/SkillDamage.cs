using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDamage : MonoBehaviour
{

    public int damage;
    private int playerproperty;
    PlayerAttack playerAttack;

    private void Start()
    {
        playerAttack = GameObject.Find("playerattack").GetComponent<PlayerAttack>();

    }
    private void Update()
    {
        playerproperty = playerAttack.playerproperty;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemies"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage, playerproperty);
                Vector2 difference = other.transform.position - transform.position;
                other.transform.position = new Vector2(other.transform.position.x + difference.x, other.transform.position.y);
            }
        }
        else if (other.gameObject.CompareTag("Bossenemies"))
        {
            Enemy bossEnemy = other.GetComponent<Enemy>();
            if (bossEnemy != null)
            {
                bossEnemy.TakeDamage(damage, playerproperty);
            }
        }
    }
}
