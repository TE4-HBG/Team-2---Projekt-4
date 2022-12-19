using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Color = UnityEngine.Color;

public class DeathScript : MonoBehaviour
{
    public GameObject Chaser;
    public GameObject Deathfloor;
    public Text GameoverText;
    public Text RestartText;
    public Button Restartknapp;
    public GameObject player;
    public Text ScoreDisplay;

    GameObject inputFieldGameObject;
    TMP_InputField inputFieldComponent;
    public string playerInput;
    public bool stringAccepted;

    void Start()    
    {
        stringAccepted = false;
        inputFieldGameObject = GameObject.Find("InputField");
        inputFieldComponent = inputFieldGameObject.GetComponent<TMP_InputField>();
        resetInputField();
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

    void resetInputField()
    {
        ColorBlock color = inputFieldComponent.colors;
        color.normalColor = new Color(255, 255, 255, 1);
        color.highlightedColor = new Color(255, 255, 255, 0);
        inputFieldComponent.colors = color;
        inputFieldComponent.image.enabled = false;
    }
    void getNameInput()
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

        getNameInput();

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
        Time.timeScale = 1f;
        ScoreCounter.displayScore = 0f;
        CoinScript.coinScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        resetInputField();

    }

    void Pause()
    {
        Time.timeScale = 0f;
    }
}

