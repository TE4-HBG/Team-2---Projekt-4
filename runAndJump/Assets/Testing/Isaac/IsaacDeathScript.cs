using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsaacDeathScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Chaser;
    public GameObject Deathfloor;
    public GameObject GameOverScreen;
    MeshFilter yourMesh;

   
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Deathfloor)
        {
            Debug.Log("game over you fell out");
            yourMesh = GameOverScreen.GetComponent<MeshFilter>();
            yourMesh.GetComponent<Renderer>().material.color = Color.white;
        }
        else if (collision.gameObject == Chaser)
        {
            Debug.Log("game over chaser killed you");
        }
    }
}
