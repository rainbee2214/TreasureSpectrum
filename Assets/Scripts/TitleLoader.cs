using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleLoader : MonoBehaviour {

    bool player1Ready, player2Ready;

    public Text player1ReadyText, player2ReadyText;

    void Update()
    {
        if (Input.GetButtonDown("Player1A") && !player1Ready)
        {
            player1Ready = true;
            player1ReadyText.text = "Ready!";
        }
        if (Input.GetButtonDown("Player2A") && !player2Ready)
        {
            player2Ready = true;
            player2ReadyText.text = "Ready!";
        }
        if (player1Ready && player2Ready) LoadGame();
    }

    public void LoadGame()
    {
        Application.LoadLevel("Level");
    }
}
