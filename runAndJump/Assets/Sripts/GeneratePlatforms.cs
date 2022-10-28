using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GeneratePlatforms : MonoBehaviour
{
    public ScoreCounter scoreCounter;

    public GameObject[,] platformArrays;

    private int platformArrayIndex;
    private int platformIndex;

    public GameObject playerObject;
    private GameObject latestPlatform;
    private GameObject coin;

    public int playerPlatformSpawnDist;
    public int platformDist;
    public int randValueY;
    public int randStartValue;
    public int randEndValue;
    public int minPlatformSpawnY;
    public int platformDistDiff;
    public int randValueForPlatforms;
    public int coinSpawnChance;

    // Start is called before the first frame update
    void Start()
    {
        platformArrays = new GameObject[6, 5];

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i == 0)
                    platformArrays[i, j] = (GameObject)Resources.Load("Prefabs/Basic/Basic" + j, typeof(GameObject));
                if (i == 1)
                    platformArrays[i, j] = (GameObject)Resources.Load("Prefabs/Moving/Moving" + j, typeof(GameObject));
                if (i == 2)
                    platformArrays[i, j] = (GameObject)Resources.Load("Prefabs/Stun/Stun" + j, typeof(GameObject));
                if (i == 3)
                    platformArrays[i, j] = (GameObject)Resources.Load("Prefabs/Speed/Speed" + j, typeof(GameObject));
                if (i == 4)
                    platformArrays[i, j] = (GameObject)Resources.Load("Prefabs/Trampoline/Trampoline" + j, typeof(GameObject));
                if (i == 5)
                    platformArrays[i, j] = (GameObject)Resources.Load("Prefabs/Falling/Falling" + j, typeof(GameObject));
            }
        }
        coin = (GameObject)Resources.Load("Prefabs/Coin", typeof(GameObject));

        platformIndex = 0;
        platformArrayIndex = 0;
        playerPlatformSpawnDist = 20;
        platformDist = 10;
        randStartValue = -3;
        randEndValue = randStartValue + 3;
        minPlatformSpawnY = -3;
        platformDistDiff = 14;

        for (int i = 0; i < 3; i++)
        {
            randValueY = Random.Range(randStartValue, randEndValue);
            latestPlatform = Instantiate(platformArrays[platformArrayIndex, platformIndex], new Vector3(platformDist, randValueY), Quaternion.identity);
            platformDist += platformDistDiff;
            randStartValue = (int)latestPlatform.transform.position.y;
            randEndValue = randStartValue + 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        randValueForPlatforms = Random.Range(0, 16);
        if (randValueForPlatforms < 11)
        {
            platformArrayIndex = 0;
        }
        else if (randValueForPlatforms == 11)
        {
            platformArrayIndex = 1;
        }
        else if (randValueForPlatforms == 12)
        {
            platformArrayIndex = 2;
        }
        else if (randValueForPlatforms == 13)
        {
            platformArrayIndex = 3;
        }
        else if (randValueForPlatforms == 14)
        {
            platformArrayIndex = 4;
        }
        else if (randValueForPlatforms == 15)
        {
            platformArrayIndex = 5;
        }

        if (scoreCounter.score <= 200)
        {
            platformIndex = 0;
        }
        else if (scoreCounter.score > 200 && scoreCounter.score <= 401)
        {
            platformIndex = 1;
        }
        else if (scoreCounter.score > 401 && scoreCounter.score <= 802)
        {
            platformIndex = 2;
        }
        else if (scoreCounter.score > 802 && scoreCounter.score <= 1003)
        {
            platformIndex = 3;
        }
        else if (scoreCounter.score > 1003)
        {
            platformDistDiff = 18;
            platformIndex = 4;
        }

        if (latestPlatform.transform.position.x - playerObject.transform.position.x < playerPlatformSpawnDist)
        {
            do
            {
                randValueY = Random.Range(randStartValue, randEndValue);
            }
            while (randValueY < minPlatformSpawnY);

            latestPlatform = Instantiate(platformArrays[platformArrayIndex, platformIndex], new Vector3(platformDist, randValueY), Quaternion.identity);
            platformDist += platformDistDiff;
            randStartValue = (int)latestPlatform.transform.position.y - 3;
            randEndValue = randStartValue + 6;

            coinSpawnChance = Random.Range(0, 10);
            if (coinSpawnChance == 0)
            {
                if (platformArrayIndex != 1)
                {
                    Instantiate(coin, new Vector3(latestPlatform.transform.position.x, latestPlatform.transform.position.y + 2), Quaternion.Euler(90, 0, 0));
                }
            }
        }
    }
}
