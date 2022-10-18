using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatforms : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject playerObject;
    private GameObject latestPlatform;
    public int playerPlatformSpawnDist;
    public int platformDist;
    public int randValueY;
    public int randStartValue;
    public int randEndValue;
    public int minPlatformSpawnY; //Add this to the code when you get back

    // Start is called before the first frame update
    void Start()
    {
        playerPlatformSpawnDist = 20;
        platformDist = 10;
        randStartValue = -3;
        randEndValue = randStartValue + 6;
        minPlatformSpawnY = -3;

        for (int i = 0; i < 3; i++)
        {
            randValueY = Random.Range(randStartValue, randEndValue);
            latestPlatform = Instantiate(platformPrefab, new Vector3(platformDist, randValueY), Quaternion.identity);
            platformDist += 12;
            randStartValue = (int)latestPlatform.transform.position.y;
            randEndValue = randStartValue + 6;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (latestPlatform.transform.position.x - playerObject.transform.position.x < playerPlatformSpawnDist)
        {
            do
            {
                randValueY = Random.Range(randStartValue, randEndValue);
            } 
            while (randValueY < minPlatformSpawnY);


            latestPlatform = Instantiate(platformPrefab, new Vector3(platformDist, randValueY), Quaternion.identity);
            platformDist += 12;
            randStartValue = (int)latestPlatform.transform.position.y -3;
            randEndValue = randStartValue + 6;
        }
    }
}
