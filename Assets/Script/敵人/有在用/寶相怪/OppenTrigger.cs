using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppenTrigger : MonoBehaviour
{
    public GameObject box_locked;
    public GameObject box;

    private Animator anim;
    public float lockTime ;


    public bool check;

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        Invoke("Ischeck", lockTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            check = true;
          

        }
    }
    private void Ischeck()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Destroy(box_locked);

            box.SetActive(true);
        }
        
    }
}
