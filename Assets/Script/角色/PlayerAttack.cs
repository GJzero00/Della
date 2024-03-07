using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class PlayerAttack : MonoBehaviour
{
    public float Qtime;
    public float QstarTime;
    private float lastAttack = -10f;
    public float attackCoolDown;
    public float SkillCoolDownQ;
    public float SkillCoolDownW;

    public int playerproperty;


    private Animator anim;
    private PolygonCollider2D collider2D;
    private BoxCollider2D boxCollider2D;
    private CapsuleCollider2D capsuleCollider2D;

    public bool SwitchS;
    public bool isattackCD;

    public Transform firePoint;
    public GameObject bulletPrefabB;
    public GameObject bulletPrefabW;
    public float bulletTime;

    public GameObject bulletW_B;
    public GameObject bulletW_W;
    private float lastSkillQTime = -10f; 
    private float lastSkillWTime = -10f; // remember the time skill been used


    public bool isTouchingWall_R;
    public bool isTouchingWall_L;
    public float wallCheckDistance;
    public Transform wallCheckR;
    public Transform wallCheckL;


    void OnEnable()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        collider2D = GetComponent<PolygonCollider2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();


       
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.D))
        {

            if (Time.time >= (lastAttack + attackCoolDown))
            {
                attackB();
                attackW();
            }
            NoAttack();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Time.time >= (lastSkillQTime + SkillCoolDownQ))
            {
                Skill_Q();
                lastSkillQTime = Time.time;
            }
            NoAttack();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Time.time >= (lastSkillWTime + SkillCoolDownW))
            {
                if (SwitchS == false)
                {
                    Skill_W_B();
                }
                else
                {
                    Skill_W_W();
                }

                lastSkillWTime = Time.time;
                NoAttack();
            }

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            ChangePlayerProperty();
        }

    }
    void ChangePlayerProperty()
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

    
    void NoAttack()
    {
        anim.SetBool("idle", true);
        anim.SetTrigger("idle");
    }

    void Skill_Q()
    {
        isattackCD = true;
        anim.SetBool("SkillQ", true);
        anim.SetTrigger("Skill_Q");
        StartCoroutine(StarSkillQ());
    }

    void Skill_W_B()
    {
        isattackCD = true;
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
        anim.SetBool("SkillW", true);
        anim.SetTrigger("Skill_W");
        Invoke("W_WTime", bulletTime);
    }
    void W_WTime()
    {
        Instantiate(bulletW_W, firePoint.position, firePoint.rotation);
    }
    


    

    IEnumerator StarSkillQ()
    {
        yield return new WaitForSeconds(Qtime);
        boxCollider2D.enabled = true;
        StartCoroutine(disableQ());
    }
    IEnumerator disableQ()
    {
        yield return new WaitForSeconds(Qtime);
        boxCollider2D.enabled = false;
    }




    

}
