using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreDisplay;
    public GameObject player;

    void Update()
    {
        scoreDisplay.text = ScoreCounter.displayScore.ToString();
    }
}
