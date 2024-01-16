using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    public GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShootArrow", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void ShootArrow()
    {
        Instantiate(arrow, transform.position, transform.rotation);


    }
}
