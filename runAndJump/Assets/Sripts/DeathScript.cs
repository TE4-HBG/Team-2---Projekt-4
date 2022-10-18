using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Chaser;
    public GameObject Deathfloor;
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Deathfloor)
        {
            Debug.Log("game over you fell out");
        }
        else if (collision.gameObject == Chaser)
        {
            Debug.Log("game over chaser killed you");
        }
    }
}
