using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public TMP_Text iqText;
    public Animator animator;
    private bool isJumping;
    private bool isGrounded;
    private Vector2 direction;
    public float iq = 1f;

    private string currentAniamtion;

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        MovementAnim();
    }

    void Update() {
        MovementAnim();


        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // передвижение персонажа по горизонтали и вертикали
        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);

        // куда персонаж идёт туди и смотрит

        if(moveX > 0)
        {
            transform.localScale = new Vector3(1f,1f,1f);

        }
        else if(moveX < 0)
        {
            transform.localScale = new Vector3(-1f,1f,1f);
        }

        //прыжок
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
            isGrounded = false;
        }


        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);


        iqText.text = "iq: " + iq;
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            isGrounded = true;
        }
    }

    void ChangeAnimation(string animation)
    {
        if(currentAniamtion == animation) return;

        animator.Play(animation);
        currentAniamtion = animation;
    }
    
    


    void MovementAnim()
    {
        if(iq <35){

            if(Input.GetKey(KeyCode.S))
            {
                ChangeAnimation("PlayerRunDown");
            }
            if(Input.GetKeyUp(KeyCode.S))
            {
                ChangeAnimation("PlayerIdle");
            }
        
            if(Input.GetKeyDown(KeyCode.D))
            {
                ChangeAnimation("PlayerRunRight");
            }
            if(Input.GetKeyUp(KeyCode.D))
            {
                ChangeAnimation("PlayerIdle");
            }

            if(Input.GetKeyDown(KeyCode.A))
            {
                ChangeAnimation("PlayerRunRight");
            }
            if(Input.GetKeyUp(KeyCode.A))
            {
                ChangeAnimation("PlayerIdle");
            }

            if(Input.GetKey(KeyCode.W))
            {
                ChangeAnimation("PlayerRunUp");
            }
            if(Input.GetKeyUp(KeyCode.W))
            {
                ChangeAnimation("PlayerIdle");
            }
        }
        if(iq >=35){
            if(Input.GetKey(KeyCode.S))
            {
                ChangeAnimation("PlayerRunDown2");
            }
            if(Input.GetKeyUp(KeyCode.S))
            {
                ChangeAnimation("PlayerIdle2");
            }
        
            if(Input.GetKeyDown(KeyCode.D))
            {
                ChangeAnimation("PlayerRunRight2");
            }
            if(Input.GetKeyUp(KeyCode.D))
            {
                ChangeAnimation("PlayerIdle2");
            }

            if(Input.GetKeyDown(KeyCode.A))
            {
                ChangeAnimation("PlayerRunRight2");
            }
            if(Input.GetKeyUp(KeyCode.A))
            {
                ChangeAnimation("PlayerIdle2");
            }

            if(Input.GetKey(KeyCode.W))
            {
                ChangeAnimation("PlayerRunUp2");
            }
            if(Input.GetKeyUp(KeyCode.W))
            {
                ChangeAnimation("PlayerIdle2");
            }
        }
        
    }
}
