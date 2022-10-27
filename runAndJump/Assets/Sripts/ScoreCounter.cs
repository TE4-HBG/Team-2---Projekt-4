using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreCounter : MonoBehaviour
{
    private float startingScore = 0;
    public float score;
    public float locationX;
    public static float displayScore;

    private void OnEnable()
    {
        score = startingScore;
    }
    void Update()
    {  
        locationX = Mathf.RoundToInt(transform.position.x - 5); // Spawnarea ends at x = 5

        if (locationX > score)
        {
            score = locationX;
        }
        displayScore = Convert.ToInt32(Math.Floor(score * 3.1415f * 5f + CoinScript.coinScore));



    }
}

