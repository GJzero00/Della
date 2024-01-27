using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    static Manager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this!=instance)
        {
            Destroy(gameObject);
        }
    }

   
    void Update()
    {
        
    }
}
