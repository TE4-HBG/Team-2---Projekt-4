using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatforms : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    public GameObject platformPrefab;
    public GameObject platformTwoPrefab;
    public GameObject platformThreePrefab;
    public GameObject platformFourPrefab;
    private GameObject platformToSpawn;
    public GameObject playerObject;
    private GameObject latestPlatform;
    public int playerPlatformSpawnDist;
    public int platformDist;
    public int randValueY;
    public int randStartValue;
    public int randEndValue;
    public int minPlatformSpawnY;
    public int platformDistDiff;
    

    // Start is called before the first frame update
    void Start()
    {
        platformToSpawn = platformPrefab;
        playerPlatformSpawnDist = 20;
        platformDist = 10;
        randStartValue = -3;
        randEndValue = randStartValue + 6;
        minPlatformSpawnY = -3;
        platformDistDiff = 12;

        for (int i = 0; i < 3; i++)
        {
            randValueY = Random.Range(randStartValue, randEndValue);
            latestPlatform = Instantiate(platformToSpawn, new Vector3(platformDist, randValueY), Quaternion.identity);
            platformDist += platformDistDiff;
            randStartValue = (int)latestPlatform.transform.position.y;
            randEndValue = randStartValue + 6;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreCounter.score > 200 && scoreCounter.score < 401)
        {
            platformToSpawn = platformTwoPrefab;
        }
        else if (scoreCounter.score > 401 && scoreCounter.score < 802)
        {
            platformDistDiff = 15;
            platformToSpawn = platformThreePrefab;
        }
        else if (scoreCounter.score > 802)
        {
            platformDistDiff = 17;
            platformToSpawn = platformFourPrefab;
        }

        if (latestPlatform.transform.position.x - playerObject.transform.position.x < playerPlatformSpawnDist)
        {
            do
            {
                randValueY = Random.Range(randStartValue, randEndValue);
            } 
            while (randValueY < minPlatformSpawnY);


            latestPlatform = Instantiate(platformToSpawn, new Vector3(platformDist, randValueY), Quaternion.identity);
            platformDist += platformDistDiff;
            randStartValue = (int)latestPlatform.transform.position.y -3;
            randEndValue = randStartValue + 6;
        }
    }
}
