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
    public float rayonUpDownForce;

    private Rigidbody2D rigidBody;
    private bool isGrounded;
    private float jumpTimeCount;
    private bool isJumping;
    private bool isFloatingUp;
    private float inputAxis;
    private float isPushedSideWay = 0f;
    private float isPushedUpDown = 0f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        inputAxis = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector2(inputAxis * speed + isPushedSideWay, rigidBody.velocity.y + isPushedUpDown); // Cancel master69
    }
    void OnTriggerStay2D(Collider2D other)
    {
        /*if (other.tag == "RepulsorUp")
            rigidBody.velocity = Vector2.up * 30;
        if (other.tag == "RepulsorDown")
            rigidBody.velocity = Vector2.down * 30;*/
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("enter");
        if (other.tag == "RepulsorLeft")
            isPushedSideWay -= 30f;
        if (other.tag == "RepulsorRight")
            isPushedSideWay += 30f;
        if (other.tag == "RepulsorUp")
            isPushedUpDown += rayonUpDownForce;
        if (other.tag == "RepulsorDown")
            isPushedUpDown -= rayonUpDownForce;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("leave");
        if (other.tag == "RepulsorLeft")
            isPushedSideWay += 30f;
        if (other.tag == "RepulsorRight")
            isPushedSideWay -= 30f;
        if (other.tag == "RepulsorUp")
            isPushedUpDown -= rayonUpDownForce;
        if (other.tag == "RepulsorDown")
            isPushedUpDown += rayonUpDownForce;
    }
    void Update()
    {
        FaceForward();
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
    private void FaceForward()
    {
        if (inputAxis < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else if (inputAxis > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
