using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_speed : MonoBehaviour
{
    public float speed = 20f;
    public float arrawDistance;

    
    public Rigidbody2D rb;
    private Vector3 starPos;
   
    void Start()
    {
        rb.velocity = transform.right * speed;
        starPos = transform.position;
    }

    void Update()
    {
        float distance = (transform.position - starPos).sqrMagnitude;
        if(distance > arrawDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemies") || other.gameObject.CompareTag("Bossenemies"))
        {
            Destroy(gameObject);
        }
    }
}
