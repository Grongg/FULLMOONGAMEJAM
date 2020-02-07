using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 0.08f;
    public float gravity = 10.0f;

    private Vector2 moveDirection = new Vector2(0, 0);
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveDirection.x = Input.GetAxis("Horizontal") * Time.deltaTime;
        moveDirection.y += -gravity * Time.deltaTime;
        if (characterController.isGrounded)
        {
            Debug.Log(characterController.isGrounded);
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        characterController.Move(moveDirection);
    }
}
