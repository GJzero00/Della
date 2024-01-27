using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    // Start is called before the first frame update

    public int speed;
    public float destorytime;  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.rotation.y == -180)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
       
        Destroy(gameObject, 1.5f);
    }
}
