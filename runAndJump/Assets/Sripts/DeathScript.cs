using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using Color = UnityEngine.Color;
using System;

public class DeathScript : MonoBehaviour
{
    public GameObject Chaser;
    public GameObject Deathfloor;
    public Text GameoverText;
    public Text RestartText;
    public Button Restartknapp;
    public GameObject player;
    public Text ScoreDisplay;
    public Text HighscoreDisplay; 

    GameObject inputFieldGameObject;
    TMP_InputField inputFieldComponent;
    public string playerInput;
    public bool stringAccepted;
    string filePath;
    string[] fileContents;
    string hsPlayer;
    string hsScore;

    void Start()
    {
        stringAccepted = false;
        inputFieldGameObject = GameObject.Find("InputField");
        inputFieldComponent = inputFieldGameObject.GetComponent<TMP_InputField>();
        ResetInputField();

        //Work on reading and writing to and from file
        filePath = Path.GetFullPath("highscore.txt");
        HandleStreamReader();
        HighscoreDisplay.text = fileContents[0] + ": " + fileContents[1];


    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R) && ScoreDisplay.fontSize == 50)
        {
            Restart();
        }
        if (stringAccepted)
            RemoveInputFieldAndUnpauseGame();

    }

    void ResetInputField()
    {
        ColorBlock color = inputFieldComponent.colors;
        color.normalColor = new Color(255, 255, 255, 1);
        color.highlightedColor = new Color(255, 255, 255, 0);
        inputFieldComponent.colors = color;
        inputFieldComponent.image.enabled = false;
    }

    void WriteToFileIfHighscore()
    {
        if (ScoreCounter.displayScore > float.Parse(hsScore))
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(playerInput);
            writer.WriteLine(ScoreCounter.displayScore);
        }
        
    }

    
    void HandleStreamReader()
    {
        if (!File.Exists(filePath))
        {
            using (File.CreateText(filePath));
        }
        fileContents = File.ReadAllLines(filePath);
        hsPlayer = fileContents[0];
        hsScore = fileContents[1];
        Debug.Log(fileContents[0] + fileContents[1]);
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
        ColorBlock colorKnapp = Restartknapp.colors;
        colorKnapp.normalColor = new Color(255, 255, 255, 255);
        colorKnapp.highlightedColor = new Color(255, 255, 255, 255);
        Restartknapp.colors = colorKnapp;


        inputFieldComponent.image.enabled = true;
        ColorBlock colorInput = inputFieldComponent.colors;
        colorInput.normalColor = new Color(255, 255, 255, 255);
        colorInput.highlightedColor = new Color(255, 255, 255, 255);
        inputFieldComponent.colors = colorInput;

        GetNameInput();

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

    public void Restart()
    {
        WriteToFileIfHighscore();
        Time.timeScale = 1f;
        ScoreCounter.displayScore = 0f;
        CoinScript.coinScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ResetInputField();

    }

    void Pause()
    {
        Time.timeScale = 0f;
    }
}

