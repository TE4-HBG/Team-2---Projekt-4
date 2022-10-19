using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kayvan : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerPos;
    private float kayvanSpeed = 10f;

    void Update()
    {
        playerPos = new Vector3(player.transform.position.x, player.transform.position.y);
        if (playerPos.x >= 2.5)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPos, kayvanSpeed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Destroy(collision.gameObject);
        }
    }
}
