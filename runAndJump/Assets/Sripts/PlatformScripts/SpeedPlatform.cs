using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpeedPlatform : MonoBehaviour
{

    PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("CoffeeMug");
        playerMovement = player.GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        playerMovement.topSpeed = 20f;
    }
}
