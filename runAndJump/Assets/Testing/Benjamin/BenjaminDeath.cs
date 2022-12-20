using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using Color = UnityEngine.Color;
using System;

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
    public Text HighscoreDisplay;
    public GameObject inputFieldGameObject;

    public static bool GameIsPaused = false;

    public TMP_InputField inputFieldComponent;
    public string playerInput;
    private bool stringAccepted;
    string filePath;
    string[] fileContents;
    string hsPlayer;
    string hsScore;

    // Start is called before the first frame update
    void Start()
    {
        stringAccepted = false;

        //Work on reading and writing to and from file
        filePath = Path.GetFullPath("highscore.txt");
        HandleStreamReader();
        GameIsPaused = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R) && GameIsPaused == true)
        {
            Restart();
        }
        if (stringAccepted)
            RemoveInputFieldAndUnpauseGame();


    }

    void WriteToFileIfHighscore()
    {
        try
        {
            if (ScoreCounter.displayScore > float.Parse(hsScore))
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(playerInput);
                    writer.WriteLine(ScoreCounter.displayScore);
                }
        }
        catch
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(playerInput);
                writer.WriteLine(ScoreCounter.displayScore);
            }
        }

    }

    void HandleStreamReader()
    {
        if (!File.Exists(filePath))
        {
            using (File.CreateText(filePath));
        }
        try
        {
            fileContents = File.ReadAllLines(filePath);
            hsPlayer = fileContents[0];
            hsScore = fileContents[1];
            Debug.Log(fileContents[0] + fileContents[1]);
            HighscoreDisplay.text = fileContents[0] + ": " + fileContents[1];
        }
        catch
        {
            Debug.Log("File empty, cannot read");
        }
       
    }

    void GetNameInput()
    {
        inputFieldComponent.onEndEdit.AddListener(AcceptStringInput);
    }

    public void AcceptStringInput(string userInput)
    {
        playerInput = userInput;
        Debug.Log(playerInput);
        stringAccepted = true;
    }

    void RemoveInputFieldAndUnpauseGame()
    {
        inputFieldComponent.onEndEdit.RemoveListener(AcceptStringInput);
        inputFieldComponent.gameObject.SetActive(false);

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

        GetNameInput();
    }

    public void Restart()
    {
        WriteToFileIfHighscore();
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
