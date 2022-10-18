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

        transform.position = Vector3.MoveTowards(transform.position, playerPos, kayvanSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Destroy(collision.gameObject);
        }
    }
}
