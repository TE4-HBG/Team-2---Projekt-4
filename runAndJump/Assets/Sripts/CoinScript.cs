using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject coin;
    public static int coinScore = 0;
    void Start()
    {
        
    }

    

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Coin")
        {
            Destroy(collision.gameObject);
            coinScore += 200;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            coinScore = 0;
        }
    }
}
