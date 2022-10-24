using Palmmedia.ReportGenerator.Core.CodeAnalysis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 16f;
    public float jumpingPower = 10f;
    private float doubleJumpingPower = 8f;

    private bool doubleJump;

    [SerializeField] public Rigidbody rb;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundLayer;

    void Update()
    {
        //Obtains the value of either -1, 0 or 1
        horizontal = Input.GetAxisRaw("Horizontal");

        //Sprint
        /*
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 16f;
        }
        else
        {
            speed = 8f;
        }
        */

        //Reactivate double jump
        if (IsGrounded() /*&& !Input.GetButtonDonw("Jump")*/)
        {
            doubleJump = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            //The player is grounded or doubleJump is true
            if (IsGrounded())
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpingPower);
            }
            else if (doubleJump)
            {
                rb.velocity = new Vector3(rb.velocity.x, doubleJumpingPower);
                doubleJump = !doubleJump;
            }
        }

        //Allows the player to jump higher
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * 0.5f);
        }

    }

    private void FixedUpdate()
    {
        //Our movement, horizontal represents direction with -1, 0, 1. Translated means a idle and d
        rb.velocity = new Vector3(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.4f, groundLayer);
        //Checks if the player has touched the ground
    }
}
