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

    [Header("SomeThingWithrancool")]
    public float restoreTime;
    private bool isOneWayPlatform;
    

    /* [Header("wallcheck")]
     public LayerMask whatIsGround;
     public Transform wallCheck;
     public float wallCheckDistance;
     public bool isTouchingWall;
     public bool isWallSliding;
     public float wallSlideSpeed;
     */


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
       
       // CheckIfWallSliding();
        
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
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.W))
        {
            if (Time.time >= (lastDash + SkillCoolDown))
            {
                
                CD();
            }
        }
        
    }

    /*  private void CheckIfWallSliding()
      {
          if(isTouchingWall  && !isGround )
          {
              isWallSliding = true;
          }
          else
          {
              isWallSliding = false;
          }

      }*/
    public void FixedUpdate()
    {

        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground) || 
                   Physics2D.OverlapCircle(groundCheck.position, 0.1f, runcoolground);
                   
        isOneWayPlatform = Physics2D.OverlapCircle(groundCheck.position, 0.1f, runcoolground);

       // isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);
       
        Dash();
        if (isDashing)
            return;

        skill();
        if (isSkill)
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

     /*   if (isWallSliding)
        {
            if (rb.velocity.y < -wallSlideSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
            }
        }*/
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

   
    void CD()
    {
        isSkill = true;

        SkillTimeLeft = dashTime;

        lastDash = Time.time;
        
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
                coll.enabled = true; // 重新啟用碰撞體
            }
        }
        else
        {
            // 如果 Dash 未激活，檢查冷卻時間
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
        // 確定是否可以 Dash，如果是，設置 Dash 的相關變數
        if (Time.time >= (lastDash + dashCoolDown))
        {
            isDashing = true;
            dashTimeLeft = dashTime;
            lastDash = Time.time;
            coll.enabled = false; // 關閉碰撞體
            
        }
    }



    void skill()
    {
        if (isSkill)
        {
            if(SkillTimeLeft > 0)
            {
                SkillTimeLeft -= Time.deltaTime;
            }
        }
        if (SkillTimeLeft <= 0)
        {
            isSkill = false;
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

   /* private void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
    }

    private void UpdateAnimations()
    {
        anim.SetBool("isWallSliding", isWallSliding);
    }*/
}
