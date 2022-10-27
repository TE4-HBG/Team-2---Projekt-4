using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float lastHorizontal;

    public float topSpeed;
    private float boostedTopSpeed; 
    private float normalSpeed; 
    private float acceleration = 36f;
    private float deceleration = 24f;
    private float decelerationTurn = 90f;
    //private float brake = 30f;
    public float jumpingPower; // Set on CoffeeMug
    public float doubleJumpingPower; // Set on CoffeeMug

    float timer;
    float currentTimer;
    bool boosted;

    private float Velocity;

    private bool doubleJump;

    private float coyoteTime = 0.1f;
    private float coyoteTimeCounter;

    [SerializeField] public Rigidbody rb;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundLayer;
    //SpeedPlatform speedPlatformScript;
    //GameObject speedPlatform;

    private void Start()
    {
        Velocity = 0f;
        //speedPlatform = GameObject.Find("SpeedPlatform"); //SpeedPlatform(clone) will be used outside of testing
        //speedPlatformScript = speedPlatform.GetComponent<SpeedPlatform>();
        timer = 0;
        currentTimer = 0;
        normalSpeed = 16f;
        boosted = false;
        topSpeed = normalSpeed;
        boostedTopSpeed = 20f;
    }

    void Update()
    {
        
        //Obtains the value of either -1, 0 or 1
        horizontal = Input.GetAxisRaw("Horizontal");

        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        rb.AddForce(0f, -3f, 0f); // Increase gravity / fallSpeed

        //Reactivate double jump
        if (IsGrounded() /*&& !Input.GetButtonDonw("Jump")*/)
        {
            doubleJump = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            //The player is grounded or doubleJump is true
            if (coyoteTimeCounter > 0f)
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

        if (topSpeed == boostedTopSpeed && !boosted)
        {
            currentTimer = timer + 100;
            boosted = true;
        }
        if (timer > currentTimer + 100)
        {
            topSpeed = 16f; // Return to normal topSpeed, should'nt be hardcoded :/
            boosted = false;
        }
       
    }
    private void FixedUpdate()
    {
        timer++;
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
                    Velocity -= acceleration * Time.deltaTime;
                    Velocity = Mathf.Max(Velocity, -1 * topSpeed);
                    rb.velocity = new Vector3(Velocity, rb.velocity.y);

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
                if (rb.velocity.x > 0) // If moving right
                {
                    Velocity -= deceleration * Time.deltaTime;
                    Velocity = Mathf.Clamp(Velocity, 0f, topSpeed);
                    rb.velocity = new Vector3(Velocity, rb.velocity.y);
                }
                else // if moving left
                {
                    Velocity += deceleration * Time.deltaTime;
                    Velocity = Mathf.Clamp(Velocity, -1 * topSpeed, 0f);
                    rb.velocity = new Vector3(Velocity, rb.velocity.y);
                }

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