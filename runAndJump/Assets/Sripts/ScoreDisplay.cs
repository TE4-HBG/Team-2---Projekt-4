using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreDisplay;
    public GameObject player;
    public float playerScore;

    void Update()
    {
        playerScore = player.GetComponent<ScoreCounter>().score;
        scoreDisplay.text = ScoreCounter.displayScore.ToString();

        if (playerScore >= 0 && playerScore < 501)
        {
            scoreDisplay.color = new Color(0, 255, 0);
        }
        else if (playerScore >= 501 && playerScore < 1001)
        {
            scoreDisplay.color = new Color(100, 100, 100);
        }
        else if (playerScore >= 1001 && playerScore < 2001)
        {
            scoreDisplay.color = new Color(0, 255, 255);
        }
        else if (playerScore >= 2001 && playerScore < 3001)
        {
            scoreDisplay.color = new Color(0, 255, 0);
        }
        else if (playerScore >= 3001 && playerScore < 50000)
        {
            scoreDisplay.color = new Color(225, 255, 0);
        }
    }
}
