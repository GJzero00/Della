using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBoss : MonoBehaviour
{
    public float speed;
    private Transform target;
    [SerializeField]
    private Animation Myanim;
    public int health;
    public int damage;

    private PlayerHealth playerHealth;
    
    public void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        target = FindObjectOfType<Playercontroller>().transform;
    }

    
    public void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
           // FindPlayer();
        
    }

    /*public void FindPlayer()
    {
        if (target.transform.position.x < transform.position.x )
        {
          transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
          transform.localScale = new Vector3(-1, 1, 1);
        }
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }*/
    public void TackDamage(int damage)
    {
        health -= damage;
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
}
