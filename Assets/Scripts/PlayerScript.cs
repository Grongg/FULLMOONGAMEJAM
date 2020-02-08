using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Transform feetPos;
    public float feetRadius;
    public LayerMask groundType;
    public float jumpTime;
    public bool doublejump;
    private Rigidbody2D rigidBody;
    private bool isGrounded;
    private float jumpTimeCount;
    private bool isJumping;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rigidBody.velocity.y);
    }

    void Update()
    {
        Jump();
    }
    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, feetRadius, groundType);
        if (isGrounded && !Input.GetButton("Jump"))
        {
            isJumping = false;
            doublejump = true;
        }
        if (!isGrounded && doublejump && Input.GetButtonDown("Jump"))
        {
            rigidBody.velocity = Vector2.up * jumpForce;
            isJumping = true;
            doublejump = false;
            jumpTimeCount = jumpTime;
        }
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rigidBody.velocity = Vector2.up * jumpForce; 
            isJumping = true;
            jumpTimeCount = jumpTime;
        }
        if (Input.GetButton("Jump") && isJumping && jumpTimeCount > 0)
        {
            rigidBody.velocity = Vector2.up * jumpForce;
            jumpTimeCount -= Time.deltaTime;
        }

    }
}
