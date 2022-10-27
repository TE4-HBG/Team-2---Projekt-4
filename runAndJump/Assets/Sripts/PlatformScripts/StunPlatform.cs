using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class StunPlatform : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    private PlayerMovement playerMovementScript;
    private int currentTimer;
    private int timer;
    bool isTouched;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        player = GameObject.Find("CoffeeMug");
        playerMovementScript = player.GetComponent<PlayerMovement>();
        rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (currentTimer + 200 >= timer && isTouched)
        {
            playerMovementScript.topSpeed = 0f;
            playerMovementScript.jumpingPower = 0f;
        }
        else if (currentTimer + 200 < timer && isTouched)
        {
            rb.velocity = new Vector3(rb.velocity.x, 20);
            isTouched = false;
            playerMovementScript.topSpeed = 16f;
            playerMovementScript.jumpingPower = 10f;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!isTouched)
        {
            currentTimer = timer;
            isTouched = true;
        }
        
       
    }
}
