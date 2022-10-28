using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kayvan : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerPos;

    private GameObject kayvan;
    private Vector3 kayvanPos;
    private float kayvanSpeed = 12f;

    void Update()
    {
        kayvan = this.gameObject;

        playerPos = new Vector3(player.transform.position.x, player.transform.position.y);
        kayvanPos = new Vector3(kayvan.transform.position.x, player.transform.position.y);

        if (playerPos.x >= 5)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPos, kayvanSpeed * Time.deltaTime);
        }

        if (playerPos.x - 250f >= kayvanPos.x)
        {
            kayvanSpeed = 35f;
        }
        else
        {
            kayvanSpeed = 14f;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
        }
    }
}
