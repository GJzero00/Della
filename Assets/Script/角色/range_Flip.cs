using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class range_Flip : MonoBehaviour
{
    private Transform bullet;
    private Transform player;
    private float horizontalMove ;
    void Start()
    {
        bullet = GameObject.FindGameObjectWithTag("bullet").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (player.localScale.x < 0)
        {
            bullet.rotation = Quaternion.Euler(0f, -180, 0f);
        }
        if(player.localScale.x > 0)
        {
            bullet.rotation = Quaternion.Euler(0f, 0f, 0f);
        }


       



    }
}
