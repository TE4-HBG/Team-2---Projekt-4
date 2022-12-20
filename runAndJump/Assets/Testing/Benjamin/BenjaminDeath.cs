using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BenjaminDeath : MonoBehaviour
{
    public GameObject Chaser;
    public GameObject Deathfloor;
    public Text GameoverText;
    public Text RestartText;
    public Button Restartknapp;
    public GameObject player;
    public Text ScoreDisplay;
    public GameObject deathPanel;

    public static bool GameIsPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        GameIsPaused = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R) && GameIsPaused == true)
        {
            Restart();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Deathfloor)
        {
            GameOver("You fell out");
        }
        else if (collision.gameObject == Chaser)
        {
            GameOver("The chaser killed you");
        }
    }

    public void GameOver(string deathState)
    {
        Pause();
        GameoverText.text = "GAME OVER " + deathState; // Visa highscore
    }

    public void RestartKnapp()
    {
        Restart();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        ScoreCounter.displayScore = 0f;
        CoinScript.coinScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    void Pause()
    {
        deathPanel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
