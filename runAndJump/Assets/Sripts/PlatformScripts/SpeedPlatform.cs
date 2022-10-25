using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpeedPlatform : MonoBehaviour
{
    private GameObject player;
    PlayerMovement playerMovement;
    public int timer;
    public int currentTimer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        GameObject player = GameObject.Find("CoffeeMug");
        playerMovement = player.GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        currentTimer = 0;
        currentTimer = timer;
        
        playerMovement.topSpeed = 30f;
    }
}
