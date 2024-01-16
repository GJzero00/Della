using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player;
    public Transform Boss;


    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            transform.position = new Vector3(Boss.position.x, 0, -10f);
        }
        else
        {
            transform.position = new Vector3(player.position.x, 0, -10f);
        }
    }
}
