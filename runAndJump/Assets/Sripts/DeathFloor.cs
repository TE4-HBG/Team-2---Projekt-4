using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFloor : MonoBehaviour
{
    public GameObject player;
    public Transform target;
    private Vector3 playerPos;

    private float speed = 100f;

    void Update()
    {
        playerPos = new Vector3(player.transform.position.x, transform.position.y);

        transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
    }
}
