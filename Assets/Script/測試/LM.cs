using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LM : Q1
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (index != 0)
        {
            if (collision.tag == "Player")
            {
                float horizontalMove = Input.GetAxisRaw("Horizontal");
                rb.velocity = new Vector2(horizontalMove * 0, rb.velocity.y);
            }
        }
    }
}
