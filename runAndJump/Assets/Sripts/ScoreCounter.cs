using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private float startingScore = 0;
    public float score;
    public float locationX;
    public float displayScore;

    void Start()
    {
        
        score = startingScore;
        locationX = score;
    }

    void Update()
    {
        
        locationX = Mathf.RoundToInt(transform.position.x);
        if (locationX <= 0) {
            score = 0 + CoinScript.coinScore;
        }
        else
        {
            score = locationX;
            displayScore = score * 100 + CoinScript.coinScore;
        }

    }
}
