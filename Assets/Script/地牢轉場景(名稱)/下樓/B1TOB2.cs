using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class B1TOB2 : MonoBehaviour
{
    public GameObject enemy;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (enemy == null)
        {
            SceneManager.LoadScene("Dungeon_B2F_2");
        }
    }
}
