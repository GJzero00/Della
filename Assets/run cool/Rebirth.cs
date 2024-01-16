using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Rebirth : MonoBehaviour
{
    public Transform backboor;

    private bool inRange;
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        EnterEnemy();
    }

    void EnterEnemy()
    {
        if (inRange)
        {
            playerTransform.position = backboor.position;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            Debug.Log("one");
            inRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            Debug.Log("two");
            inRange = false;
        }
    }
}

