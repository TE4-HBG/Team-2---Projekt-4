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

    

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Coin(Clone)")
        {
            Destroy(collision.gameObject);
            coinScore += 1500;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
