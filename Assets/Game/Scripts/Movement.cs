﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private LayerMask enviromentLayer;

    private Rigidbody rb;
    private Animator anim;
    private int jumpCount;

    public MovementData Data { get; set; }
    private float speed
    {
        get
        {
            return Data.Speed;
        }
    }
    private int maxJumps
    {
        get
        {
            return Data.MaxJumps;
        }
    }
    private float jumpForce
    {
        get
        {
            return Data.JumpForce;
        }
    }
    private bool isGrounded
    {
        get
        {
            return Physics.Raycast(transform.position + Vector3.up * 0.05f, Vector3.down, 0.15f, enviromentLayer);
        }
    }
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        anim.SetBool("IsGrounded", isGrounded);
    }

    public void Move(float x, float y)
    {
        var input = Vector3.ClampMagnitude(new Vector3(x, 0f, y), 1f);
        var mov = input * speed;

        rb.velocity = new Vector3(mov.x, rb.velocity.y, mov.z);
        if (input.magnitude > 0.1f)
            transform.rotation = Quaternion.LookRotation(input);
        if (isGrounded)
            jumpCount = 0;

        anim.SetFloat("Velocity", input.magnitude);

        rb.angularVelocity = Vector3.zero;
    }

    public void Jump()
    {
        if (jumpCount >= maxJumps - 1) return;
        jumpCount++;
        anim.SetTrigger("Jump");
        rb.AddForce(Vector3.up * jumpForce);
    }
}
