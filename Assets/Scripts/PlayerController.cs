using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private bool isJumping;
    private bool isGrounded;
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        
        float moveX = Input.GetAxis("Horizontal");

        // передвижение персонажа по горизонтали
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

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
