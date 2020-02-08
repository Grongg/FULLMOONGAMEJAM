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
    private bool isFloatingUp;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rigidBody.velocity.y); // Cancel master69
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "RepulsorUp")
            rigidBody.velocity = Vector2.up * 30;
        if (other.tag == "RepulsorDown")
            rigidBody.velocity = Vector2.down * 30;
        if (other.tag == "RepulsorLeft")
            rigidBody.velocity = new Vector2(1f * 30, rigidBody.velocity.y); // Cancelled by the new vector2 in FixedUpdate() for idk wad reason
        if (other.tag == "RepulsorRight")
            rigidBody.velocity = new Vector2(1f * 30, rigidBody.velocity.y); // Cancelled by the new vector2 in FixedUpdate() for idk wad reason
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
