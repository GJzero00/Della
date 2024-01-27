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
    // public int Coin, Key;


    public Text CoinNum;

    [Header("CD的UI組件")]
    public Image cdImage;
    public Image cdImage2;

    [Header("Dash參數")]
    public float dashTime; //dash時長
    private float dashTimeLeft; //衝鋒剩餘時間
    private float lastDash = -10f;//上一次dash時間點
    public float dashCoolDown;
    public float dashSpeed;
    public float SkillCoolDown;
    private float SkillTimeLeft;


    public bool isGround, isJump, isDashing,isSkill;

    bool jumpPressed;
    int jumpCount;

    [Header("平台上下")]
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
                //可以執行dash
                ReadyToDash();
            }
           
               
        }
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.W))
        {
            if (Time.time >= (lastDash + SkillCoolDown))
            {
                //可以執行dash
                CD();
            }
        }
        cdImage.fillAmount -= 1.0f / SkillCoolDown * Time.deltaTime;
        cdImage2.fillAmount -= 1.0f / SkillCoolDown * Time.deltaTime;
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

   void ReadyToDash()
    {
        isDashing = true;

        dashTimeLeft = dashTime;

        lastDash = Time.time;
       

    }
    void CD()
    {
        isSkill = true;

        SkillTimeLeft = dashTime;

        lastDash = Time.time;
        cdImage.fillAmount = 1;
        cdImage2.fillAmount = 1;
    }

    void Dash()
    {
        if (isDashing)
        {
            if(dashTimeLeft > 0)
            {
                rb.velocity = new Vector2(dashSpeed * horizontalMove, rb.velocity.y);

                dashTimeLeft -= Time.deltaTime;

                ShadowPool.instance.GetFormPool();
            }
        }
        if(dashTimeLeft <= 0)
        {
            isDashing = false;
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
