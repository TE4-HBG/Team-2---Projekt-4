using Palmmedia.ReportGenerator.Core.CodeAnalysis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float lastHorizontal;

    public float topSpeed; // Set on CoffeeMug
    public float boostedTopSpeed; // Set on CoffeeMug
    private float acceleration = 36f;
    private float deceleration = 24f;
    private float decelerationTurn = 38f;
    //private float brake = 30f;
    public float jumpingPower; // Set on CoffeeMug
    public float doubleJumpingPower; // Set on CoffeeMug

    private float Velocity;


    private bool doubleJump;

    [SerializeField] public Rigidbody rb;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundLayer;
    SpeedPlatform speedPlatformScript;
    GameObject speedPlatform;

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


        Debug.Log(rb.velocity.x);
        rb.AddForce(0f, -3f, 0f); // Increase gravity / fallSpeed

        //Obtains the value of either -1, 0 or 1
        horizontal = Input.GetAxisRaw("Horizontal");


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

        /*
        //Allows the player to jump higher
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
          rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * 1f);
        }
        */

        if (topSpeed == boostedTopSpeed)
        {
            if (speedPlatformScript.timer > speedPlatformScript.currentTimer + 600)
            {
                topSpeed = 10f; // Return to normal topSpeed, should'nt be hardcoded :/
            }
        }
        speedPlatformScript.timer++;
    }

    private void FixedUpdate()
    {
        //Our movement, horizontal represents direction with -1, 0, 1. Translated means a idle and d
        if (horizontal != 0) // If holding down A or D
        {
            if (horizontal == 1) // Holding down D
            {
                if (rb.velocity.x < 0) // If moving to the left
                {
                    Velocity = rb.velocity.x + (decelerationTurn * Time.deltaTime);
                }
                else
                {
                    Velocity += acceleration * Time.deltaTime;
                    Velocity = Mathf.Min(Velocity, topSpeed);
                }
                rb.velocity = new Vector3(Velocity, rb.velocity.y);
            }
            else if (horizontal == -1) // Holding down A
            {
                if (rb.velocity.x > 0) // If moving to the right
                {
                    Velocity = rb.velocity.x - (decelerationTurn * Time.deltaTime);
                    rb.velocity = new Vector3(Velocity, rb.velocity.y);
                }
                else
                {
                    Velocity += acceleration * Time.deltaTime;
                    Velocity = Mathf.Min(Velocity, topSpeed);
                    rb.velocity = new Vector3(horizontal * Velocity, rb.velocity.y);
                } 
            }
            
            lastHorizontal = horizontal;
        }
        else
        {
            if (rb.velocity.x == 0)
            {
                Velocity = 0;
            }
            else
            {
                Velocity -= deceleration * Time.deltaTime;
                Velocity = Mathf.Clamp(Velocity, 0f, topSpeed);
                rb.velocity = new Vector3(lastHorizontal * Velocity, rb.velocity.y);
            }
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.4f, groundLayer);
        //Checks if the player has touched the ground
    }

    /*void Brake()
    {
        Velocity -= brake * Time.deltaTime;
        Velocity = Mathf.Clamp(Velocity, 0f, topSpeed);
    }*/
}