using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playercontroller : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public Collider2D coll;

    public float speed, jumpForce;
    private float horizontalMove;
    public Transform groundCheck;
    public LayerMask ground;
    public LayerMask runcoolground;

    [Header("Dash Controll")]
    public float dashTime; 
    private float dashTimeLeft; 
    private float lastDash = -10f;
    public float dashCoolDown;
    public float dashSpeed;
    public float SkillCoolDown;
    private float SkillTimeLeft;
    public float collDisabledTime;


    public bool isGround, isJump, isDashing,isSkill;

    bool jumpPressed;
    int jumpCount;

    [Header("Parkour Platform Drop")]
    public float restoreTime;
    private bool isOneWayPlatform;
    

   


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
       
        
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpPressed = true;
        }


        if (Input.GetKeyDown(KeyCode.LeftShift) )
        {
            if(Time.time >= (lastDash + dashCoolDown) )
            {
                
                ReadyToDash();
            }
           
               
        }
      
    }

    
    public void FixedUpdate()
    {

        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground) || 
                   Physics2D.OverlapCircle(groundCheck.position, 0.1f, runcoolground);
                   
        isOneWayPlatform = Physics2D.OverlapCircle(groundCheck.position, 0.1f, runcoolground);

       
       
        Dash();
        if (isDashing)
            return;


        GroundMovement();
      
        Jump();

        SwitchAnim();

        OnWayPlatformCheck();

    }
    void GroundMovement()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);

       

        if (horizontalMove != 0)
       {
              transform.localScale = new Vector3(horizontalMove, 1, 1);
       }

    
    }
    
    void Jump()
    {
        if (isGround)
        {
            jumpCount = 1;
            isJump = false;
        }
        if (jumpPressed && isGround)
        {
            isJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
        }
        else if (jumpPressed && jumpCount > 0 && isJump) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
        }
    }

    void SwitchAnim()
    {
        anim.SetFloat("running", Mathf.Abs(rb.velocity.x));

        if (isGround)
        {
            anim.SetBool("falling", false);
        }
        else if (!isGround && rb.velocity.y > 0)
        {
            anim.SetBool("jumping", true);
        }
        else if (rb.velocity.y < 0)
        {
            anim.SetBool("jumping", false);
            anim.SetBool("falling", true);
        }
    }

   
  

    void Dash()
    {
        if (isDashing)
        {
            if (dashTimeLeft > 0)
            {
                
                rb.velocity = new Vector2(dashSpeed * horizontalMove, rb.velocity.y);
                dashTimeLeft -= Time.deltaTime;
            }
            else
            {
                
                isDashing = false;
                coll.enabled = true;  //when dash is finish , turn it on 
            }
        }
        else
        {
            // If Dash is not active, check cooldown time
            if (Time.time >= (lastDash + dashCoolDown))
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    ReadyToDash();
                }
            }
        }
    }

    void ReadyToDash()
    {
        //Determine whether Dash can be used, and if so, set Dash-related variables
        if (Time.time >= (lastDash + dashCoolDown))
        {
            isDashing = true;
            dashTimeLeft = dashTime;
            lastDash = Time.time;
            coll.enabled = false; // close coll to be Invincible because no coll will be trigger


        }
    }



    
    void OnWayPlatformCheck()
    {
        if(isGround && gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
        
        float moveY  = Input.GetAxisRaw("Vertical");

        if (isOneWayPlatform && moveY < -0.1f)
        {
            gameObject.layer = LayerMask.NameToLayer("runcoolPlayer");
            Invoke("RestorePlayerLayer", restoreTime);
        }
    }

    void RestorePlayerLayer()
    {
        if (!isGround && gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
    }


}
