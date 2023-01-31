using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    private float movInput;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer rend;
    private TrailRenderer dashLine;
    public Transform DashPosition;
    public GameObject LightFront, LightBack, DashBurst;
    private bool activeLight1, activeLight2;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask isGround;
    public float jumpForce;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    private bool canDash = true;
    public bool isDashing;
    private float dashForce = 20f;
    private float dashTime = 0.2f;
    private float dashTimeCD = 0.3f;

    public AttackController AC;
    


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        dashLine = GetComponent<TrailRenderer>();
    }
    
    private void Update()
    {
        if (isDashing)
        {
            return;
        }

        Jump();
        
        if (Input.GetKeyDown(KeyCode.X) && canDash)
        {
            StartCoroutine(Dash());
            
        }
    }
    
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        
        Move();
        
    }
    
  
    
    
    private void Move()
    {
        movInput = Input.GetAxisRaw("Horizontal");
        //transform.position += new Vector3(movx * speed, 0, 0);
        
        rb.velocity = new Vector2(movInput * speed, rb.velocity.y);

        if (movInput > 0)
        {
            animator.SetBool("IsMoving", true);
            
            if(AC.isAttacking) return;
            
            transform.eulerAngles = new Vector3(0, 0, 0);
            
            if(activeLight1) return;
            
            LightFront.SetActive(true);
            LightBack.SetActive(false);
            activeLight2 = false;

        }
        else if (movInput < 0)
        {
            animator.SetBool("IsMoving", true);
            
            if(AC.isAttacking) return;
            
            transform.eulerAngles = new Vector3(0, 180, 0);
            
            if(activeLight2) return;
            
            LightFront.SetActive(false);
            LightBack.SetActive(true);
            activeLight1 = false;
        }
        else if (movInput == 0)
        {
            animator.SetBool("IsMoving", false);

        }
        

    }
    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, isGround);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            
        }
    }
    private IEnumerator Dash()
    {
        var dburst = Instantiate(DashBurst, DashPosition.position, DashPosition.rotation);
        Destroy(dburst, 0.5f);
        dashLine.emitting = true;
        
        canDash = false;
        isDashing = true;
        rb.gravityScale = 0f;

        rb.velocity = movInput switch
        {
            < 0 => new Vector2(-1 * dashForce, 0f),
            > 0 => new Vector2(1 * dashForce, 0f),
            _ => rb.velocity
        };

        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = 5f;
        dashLine.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashTimeCD);
        canDash = true;
    }
}
