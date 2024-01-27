using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PlayerAttack_Melee : MonoBehaviour
{

    public float time;
    public float starTime;
    private float lastAttack = -10f;
    public float attackCoolDown;

    public int playerproperty;//black=0 white=1;
    public int enemy = Enemy.enemyproperty;

    private Animator anim;
    private PolygonCollider2D collider2D;

    public bool SwitchS;
    public bool isattackCD;

    public Transform firePoint;//子彈位置
    public GameObject bulletPrefab;//產生子彈

    private bool checkMelee = false;
    void OnEnable()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        collider2D = GetComponent<PolygonCollider2D>();

        starTime = Time.time;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (Time.time >= (lastAttack + attackCoolDown ))
            {
                if(checkMelee == true)
                {
                    Melee();
                }
            }
            NOattack();
        }
       

    }
    void Melee()
    {

        isattackCD = true;
        lastAttack = Time.time;
        starTime = time;
        anim.SetTrigger("melee");
        anim.SetBool("melee", true);
        StartCoroutine(StarAttack());
    }
    void NOattack()
    {
        anim.SetBool("idle", true);
        anim.SetTrigger("idle");
    }

    IEnumerator StarAttack()
    {
        yield return new WaitForSeconds(starTime);
        collider2D.enabled = true;
        StartCoroutine(disableHitBox());
    }


    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        collider2D.enabled = false;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemies"))
        {
            checkMelee = true;
        }
    }
}
