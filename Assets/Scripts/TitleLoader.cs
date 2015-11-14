using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleLoader : MonoBehaviour
{

    public float gameStartDelay = 1f;
    bool player1Ready, player2Ready;

    public Text player1ReadyText, player2ReadyText;

    public string[] startingComments;

    void Awake()
    {
        if (startingComments == null || startingComments.Length == 0)
        {
            startingComments = new string[2];
            startingComments[0] = "Lets go!";
            startingComments[1] = "Time to party!";
        }
    }
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
        if (player1Ready && player2Ready)
        {
            player1Ready = false;
            player2Ready = false;
            LoadGame();
        }
    }

    public void LoadGame()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        player1ReadyText.text = startingComments[(Random.Range(0, startingComments.Length))];
        player2ReadyText.text = startingComments[(Random.Range(0, startingComments.Length))];

        yield return new WaitForSeconds(gameStartDelay);
        Application.LoadLevel("Level");
    }
}
