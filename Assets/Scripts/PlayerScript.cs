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
    public float limitSpeed;

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
        float xVelocity = isPushedSideWay;
        float yVelocity = rigidBody.velocity.y + isPushedUpDown;

        inputAxis = Input.GetAxis("Horizontal");
        xVelocity += inputAxis * speed;
        if (xVelocity > limitSpeed)
            xVelocity = limitSpeed;
        if (xVelocity < -limitSpeed)
            xVelocity = -limitSpeed;
        if (yVelocity > limitSpeed)
            yVelocity = limitSpeed;
        if (yVelocity < -limitSpeed)
            yVelocity = -limitSpeed;
        rigidBody.velocity = new Vector2(xVelocity, yVelocity); // Cancel master69
        Debug.Log(yVelocity);
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
