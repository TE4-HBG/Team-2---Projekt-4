using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsaacDeathScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Chaser;
    public GameObject Deathfloor;
    public Text GameoverText;
    public Text RestartText;
    public Button Restartknapp;
    public GameObject player;


   
    void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Deathfloor)
        {
            Debug.Log("game over you fell out");
            gameOver("You fell out");

        }
        else if (collision.gameObject == Chaser)
        {
            Debug.Log("game over chaser killed you");
            gameOver("The chaser killed you");
        }
    }

    public void gameOver(string deathState)
    {
        GameoverText.text = "GAME OVER" + "     " + deathState; // Visa highscore
        RestartText.color = new Color(0, 0, 0, 255);
        Restartknapp.image.enabled = true;
        ColorBlock color = Restartknapp.colors;
        color.normalColor = new Color(255, 255, 255, 255);
        Restartknapp.colors = color;
    }

    public void restart()
    {
        GameoverText.text = "";
        RestartText.color = new Color(0, 0, 0, 0);
        ColorBlock color = Restartknapp.colors;
        color.normalColor = new Color(255, 255, 255, 1);
        Restartknapp.colors = color;
        Restartknapp.image.enabled = false;
        player.transform.position = new Vector3(0, 2, 0);

    }
}
