using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 0.08f;
    public float gravity = 10.0f;

    private float time = 0;
    private Vector2 moveDirection = new Vector2(0, 0);
    private CharacterController characterController;
    private float truc = 0;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveDirection.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        if (characterController.isGrounded)
        {
            moveDirection.y = -0.1f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpSpeed;
                /*Debug.Log("Direction : " + moveDirection.y);*/
            }
        } else
        {
            moveDirection.y += -gravity * Time.deltaTime;
        }
        characterController.Move(moveDirection);
    }
}
