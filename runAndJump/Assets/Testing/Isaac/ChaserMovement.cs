using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public int ChaserSpeed = 2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * ChaserSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        /* Debug.Log("Collision detected");
        if (collision.gameObject == Player)
        {
        }
        else
        {
            Debug.Log("Destroyed platform");
            Destroy(collision.gameObject);
        }
        */
    }
}
