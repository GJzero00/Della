using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSprite : MonoBehaviour
{
    private Transform player;

    private SpriteRenderer thisSprite; //當前圖像
    private SpriteRenderer playerSprite; //玩家圖像

    private Color color;// 1是100%

    [Header("時間控制參數")]
    public float activeTime; //顯示時間
    public float activeStart; //開始顯示時間點

    [Header("不透明度控制")]
    private float alpha;
    public float alphaSet;//初始值
    public float alphaMultiplier;     


    private  void OnEnable()  //衝刺殘影
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

        color = new Color(0, 0, 1, alpha); //(0,0,1)灰色

        thisSprite.color = color;

        if(Time.time >= activeStart + activeTime)
        {
            //返回對象池
            ShadowPool.instance.ReturnPool(this.gameObject);
        }
    }
}
