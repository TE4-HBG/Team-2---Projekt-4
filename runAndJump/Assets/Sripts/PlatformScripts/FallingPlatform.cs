using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public bool isTouched;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        isTouched = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isTouched)
        {
            if (rb.transform.position.y >= -20)
            {
                rb.velocity = new Vector3(0, -4);
            }
            else
            {
                Destroy(gameObject);
            }    
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isTouched = true;
    }
}
