using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatformsTim : MonoBehaviour
{
    public ScoreCounter scoreCounter;

    public GameObject[,] platformArrays;
    //public GameObject[] basicPlatforms;

    private int platformArrayIndex;
    private int platformIndex;

    public GameObject playerObject;
    private GameObject latestPlatform;

    public int playerPlatformSpawnDist;
    public int platformDist;
    public int randValueY;
    public int randStartValue;
    public int randEndValue;
    public int minPlatformSpawnY;
    public int platformDistDiff;
    public int randValueForPlatforms;

    // Start is called before the first frame update
    void Start()
    {
        platformArrays = new GameObject[6,5]; 

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
        
        platformIndex = 0;
        platformArrayIndex = 0;
        playerPlatformSpawnDist = 20;
        platformDist = 10;
        randStartValue = -3;
        randEndValue = randStartValue + 3;
        minPlatformSpawnY = -3;
        platformDistDiff = 12;

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
        randValueForPlatforms = 3;
        if (randValueForPlatforms == 0)
        {
            platformArrayIndex = 0;
        }
        else if (randValueForPlatforms == 1)
        {
            platformArrayIndex = 1;
        }
        else if (randValueForPlatforms == 2)
        {
            platformArrayIndex = 2;
        }
        else if (randValueForPlatforms == 3)
        {
            platformArrayIndex = 3;
        }
        else if (randValueForPlatforms == 4)
        {
            platformArrayIndex = 4;
        }
        else if (randValueForPlatforms == 5)
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
            platformDistDiff = 15;
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
            randStartValue = (int)latestPlatform.transform.position.y -3;
            randEndValue = randStartValue + 6;
        }
    }
}
