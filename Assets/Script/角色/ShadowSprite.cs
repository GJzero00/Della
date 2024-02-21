using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSprite : MonoBehaviour
{
    private Transform player;

    private SpriteRenderer thisSprite; 
    private SpriteRenderer playerSprite; 

    private Color color;

    [Header("�r�g���ƅ���")]
    public float activeTime; 
    public float activeStart; 

    [Header("��͸���ȿ���")]
    private float alpha;
    public float alphaSet;
    public float alphaMultiplier;     


    private  void OnEnable()  
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        thisSprite = GetComponent<SpriteRenderer>();
        playerSprite = player.GetComponent<SpriteRenderer>();

        alpha = alphaSet;

        thisSprite.sprite = playerSprite.sprite;

        transform.position = player.position;
        transform.localScale = player.localScale;
        transform.rotation = player.rotation;

        activeStart = Time.time;
    }

    void Update()
    {
        alpha *= alphaMultiplier;

        color = new Color(0, 0, 0, alpha); 

        thisSprite.color = color;

        if(Time.time >= activeStart + activeTime)
        {
            
            ShadowPool.instance.ReturnPool(this.gameObject);
        }
    }
}
