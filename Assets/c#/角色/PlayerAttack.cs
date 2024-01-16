using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class PlayerAttack : MonoBehaviour
{

    public int damage;
    public float meleetime;
    public float meleestarTime;
    public float Qtime;
    public float QstarTime;
    public float Wtime;
    public float WstarTime;
    private float lastAttack = -10f;
    public float attackCoolDown;
    public float SkillCoolDown;

    public int playerproperty;
    public int enemy = Enemy.enemyproperty;

    private Animator anim;
    private PolygonCollider2D collider2D;
    private BoxCollider2D boxCollider2D;
    private CapsuleCollider2D capsuleCollider2D;

    public bool SwitchS;
    public bool isattackCD;

    public Transform firePoint;//子?位置
    public GameObject bulletPrefabB;//產生子?
    public GameObject bulletPrefabW;
    public float bulletTime;
   
    public GameObject bulletW_B;
    public GameObject bulletW_W;

    private Vector2 enemies;


    public bool isTouchingWall_R;
    public bool isTouchingWall_L;
    public float wallCheckDistance;
    public Transform wallCheckR;
    public Transform wallCheckL;
    public LayerMask whatIsGround;

    void OnEnable()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        collider2D = GetComponent<PolygonCollider2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
       

        meleestarTime = Time.time;
        QstarTime = Time.time;
        WstarTime = Time.time;
    }

    void Update()
    {
        CheckSurroundings();
        if (Input.GetKeyDown(KeyCode.D))
        {

            if (Time.time >= (lastAttack + attackCoolDown))
            {

                if (isTouchingWall_R || isTouchingWall_L)
                {

                    Melee();
                }

                else
                {
                    attackB();
                    attackW();

                }
            }
            NOattack();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Time.time >= (lastAttack + SkillCoolDown))
            {
                Skill_Q();
            }
             NOattack();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Time.time >= (lastAttack + SkillCoolDown))
            {
                if (SwitchS == false) 
                {
                    Skill_W_B();
                }
                else
                {
                    Skill_W_W();
                }
                NOattack();
            }
           
        }

        if (Input.GetKeyDown(KeyCode.S))
        {

            if (SwitchS)
            {
                Black();

            }
            else
            {
                White();
            }
        }

    }
        void White()
        {
            playerproperty = 1;
            SwitchS = true;
            anim.SetTrigger("S");
            anim.SetBool("W", true);
            anim.SetBool("B", false);
        }

        void Black()
        {
            playerproperty = 0;
            SwitchS = false;
            anim.SetTrigger("S");
            anim.SetBool("B", true);
            anim.SetBool("W", false);
        }

        void attackB()
        {
            if (playerproperty == 0)
            {
                Instantiate(bulletPrefabB, firePoint.position, firePoint.rotation);
            }
            isattackCD = true;
            lastAttack = Time.time;
            anim.SetTrigger("AttackB");

        }
        void attackW()
        {
            if (playerproperty == 1)
            {
                Instantiate(bulletPrefabW, firePoint.position, firePoint.rotation);
            }
            isattackCD = true;
            lastAttack = Time.time;
            anim.SetTrigger("AttackW");
        }

        void Melee()
        {
            isattackCD = true;
            lastAttack = Time.time;
            meleestarTime = meleetime;
            anim.SetTrigger("melee");
            anim.SetBool("melee", true);
            StartCoroutine(StarAttack());
        }
        void NOattack()
        {
            anim.SetBool("idle", true);
            anim.SetTrigger("idle");
        }

        void Skill_Q()
        {
            isattackCD = true;
            lastAttack = Time.time;
            QstarTime = Qtime;
            anim.SetBool("SkillQ",true);
            anim.SetTrigger("Skill_Q");
        StartCoroutine(StarSkillQ());
        }

       void Skill_W_B()
       {
        isattackCD = true;
        lastAttack = Time.time;
        WstarTime = Wtime;
        anim.SetBool("SkillW", true);
        anim.SetTrigger("Skill_W");
        Invoke("W_BTime", bulletTime);
       }
    void W_BTime()
    {
        Instantiate(bulletW_B, firePoint.position, firePoint.rotation);
    }
    void Skill_W_W()
    {
        isattackCD = true;
        lastAttack = Time.time;
        WstarTime = Wtime;
        anim.SetBool("SkillW", true);
        anim.SetTrigger("Skill_W");
        Invoke("W_WTime", bulletTime);
    }
    void W_WTime()
    {
        Instantiate(bulletW_W, firePoint.position, firePoint.rotation);
    }
    IEnumerator StarAttack()
        {
            yield return new WaitForSeconds(meleestarTime);
            collider2D.enabled = true;
            StartCoroutine(disableHitBox());
        }


        IEnumerator disableHitBox()
        {
            yield return new WaitForSeconds(meleetime);
            collider2D.enabled = false;
        }

    IEnumerator StarSkillQ()
    {
        yield return new WaitForSeconds(QstarTime);
        boxCollider2D.enabled = true;
        StartCoroutine(disableQ());
    }
    IEnumerator disableQ()
    {
        yield return new WaitForSeconds(Qtime);
        boxCollider2D.enabled = false;
    }
    

    void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("enemies"))
            {
                other.GetComponent<Enemy>().TakeDamage(damage, playerproperty, enemy);
                Vector2 difference = other.transform.position - transform.position;
                other.transform.position = new Vector2(other.transform.position.x + difference.x, other.transform.position.y + difference.y);
            }
            if (other.gameObject.CompareTag("Bossenemies"))
            {
                other.GetComponent<Enemy>().TakeDamage(damage, playerproperty, enemy);

            }
        }

         void CheckSurroundings()
        {
            isTouchingWall_R = Physics2D.Raycast(wallCheckR.position, transform.right, wallCheckDistance, whatIsGround);
            isTouchingWall_L = Physics2D.Raycast(wallCheckL.position, transform.right, wallCheckDistance, whatIsGround);
        }

    }
