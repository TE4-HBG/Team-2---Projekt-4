using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolinePlatform : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("CoffeeMug");
        rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
      rb.velocity = new Vector3(rb.velocity.x, 20);
    }
}
