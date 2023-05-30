using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Animator animator;
    private bool isJumping;
    private bool isGrounded;
    private Vector2 direction;

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // передвижение персонажа по горизонтали
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
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            isGrounded = true;
        }
    }
}
