using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public GameObject player;
    public Transform target;
    private Vector3 playerPos;
    public float backDistY;

    private float speed = 100f;

    void Update()
    {
        playerPos = new Vector3(player.transform.position.x, backDistY, 0);

        transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);

        transform.Rotate(0, -0.005f, 0 * Time.deltaTime);
    }
}
