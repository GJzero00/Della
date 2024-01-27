using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeyCheck : MonoBehaviour
{
    public bool isClick;
    public float tempTime = 0;
    public Button Btn;

    void Awake()
    {
        Btn.onClick.AddListener(OnClick);
    }

    
    void Update()
    {
        if (isClick)
        {
            tempTime += Time.deltaTime;
            if(tempTime > 2)
            {
                tempTime = 0;
                
                isClick = false;
            }
        }
    }

    public  void OnClick()

    {
        isClick = true;
        
    }
}
