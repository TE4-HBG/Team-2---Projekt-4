using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 spawnPos;
    private bool goingLeft;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = new Vector3(transform.position.x, transform.position.y);
        endPos = new Vector3(spawnPos.x + 3, spawnPos.y);
        startPos = new Vector3(spawnPos.x - 3, spawnPos.y);
        goingLeft = false;
        rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= endPos.x && !goingLeft)
        {
            goingLeft = true;
            rb.velocity = new Vector3(-5, 0);
        }
        else if (transform.position.x <= startPos.x && goingLeft)
        {
            goingLeft = false;
            rb.velocity = new Vector3(5, 0);
        }

    }
}

