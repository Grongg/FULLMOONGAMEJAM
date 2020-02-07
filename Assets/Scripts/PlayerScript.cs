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
    private bool grouded = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveDirection.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        if (characterController.isGrounded)
        {
            moveDirection.y = 0;
            if (!grouded)
            {
                Debug.Log("Time : " + time);
                grouded = true;
            }
            if (Input.GetButtonDown("Jump"))
            {
                time = 0;
                moveDirection.y = jumpSpeed;
                grouded = false;
                Debug.Log("Direction : " + moveDirection.y);
            }
        }
        time += Time.deltaTime;
        moveDirection.y += -gravity * Time.deltaTime;
        characterController.Move(moveDirection);
    }
}
