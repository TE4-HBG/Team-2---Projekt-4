using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SakdaDeathScript : MonoBehaviour
{
    public GameObject Chaser;
    public GameObject Deathfloor;
    public Text GameoverText;
    public Text RestartText;
    public Button Restartknapp;
    public GameObject player;
    public Text ScoreDisplay;

    void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Restart();
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Deathfloor)
        {
            Debug.Log("game over you fell out");
            GameOver("You fell out");
        }
        else if (collision.gameObject == Chaser)
        {
            Debug.Log("game over chaser killed you");
            GameOver("The chaser killed you");
        }
    }

    public void GameOver(string deathState)
    {
        Pause();
        ScoreDisplay.fontSize = 50;
        GameoverText.text = "GAME OVER" + "     " + deathState; // Visa highscore
        RestartText.color = new Color(0, 0, 0, 255);
        Restartknapp.image.enabled = true;
        ColorBlock color = Restartknapp.colors;
        color.normalColor = new Color(255, 255, 255, 255);
        color.highlightedColor = new Color(255, 255, 255, 255);
        Restartknapp.colors = color;
        
        
    }

    public void RestartKnapp()
    {
        GameoverText.text = "";
        RestartText.color = new Color(0, 0, 0, 0);
        ColorBlock color = Restartknapp.colors;
        color.normalColor = new Color(255, 255, 255, 1);
        color.highlightedColor = new Color(255, 255, 255, 0);
        Restartknapp.colors = color;
        Restartknapp.image.enabled = false;
        player.transform.position = new Vector3(0, 2, 0);
        Restart();
    }

    void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Pause()
    {
        Time.timeScale = 0f;
    }
}

