using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
   public GameObject createEnemy;
    public GameObject Enemy;
    private float timer;
    public float timerset;
   
    


    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("SpawnEnemy", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        Debug.Log(timer);

    }

    public void SpawnEnemy()
    {
        
            
        



        Instantiate(Enemy, createEnemy.transform.position, createEnemy.transform.rotation);

        if (timer > timerset)
        {
            Destroy(gameObject);
        } 
                
        
         

            

        

       

                                                                                     
        
    }
}
