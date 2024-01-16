using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CD : MonoBehaviour
{
    public float coldTime = 0.1f;
    
    private float timer = 0;
    private Image filledImage;
    private bool isStartTime = false;

    void Start()
    {
        filledImage = transform.Find("FillImage").GetComponent<Image>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            isStartTime = true;
           
        if (isStartTime)
        {
            timer += Time.deltaTime;
            filledImage.fillAmount = (coldTime - timer) / coldTime;
            
            if(timer >= coldTime)
            {
                filledImage.fillAmount = 0;
                timer = 0;
                isStartTime = false;
            }
        }
    }
    public void OnShow()
    {
        isStartTime = true;
    }
}
