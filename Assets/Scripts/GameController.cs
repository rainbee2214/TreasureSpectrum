using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController controller;

    #region 
    public float minPosition = -22.5f, maxPosition = 67.5f;


    private float player1BatteryLevel = 1, player2BatteryLevel = 1;
    public float Player1BatteryLevel
    {
        get { return player1BatteryLevel; }
        set { player1BatteryLevel += value; }
    }
    public float Player2BatteryLevel
    {
        get { return player2BatteryLevel; }
        set { player2BatteryLevel += value; }
    }
    private int player1TreasureCount, player2TreasureCount, currentLevelTreasureCount, currentRound;

    public int Player1TreasureCount
    {
        get { return player1TreasureCount; }
        set { player1TreasureCount += value; }
    }
    public int Player2TreasureCount
    {
        get { return player2TreasureCount; }
        set { player2TreasureCount += value; }
    }

    public int CurrentLevelTreasureCount
    {
        get { return currentLevelTreasureCount; }
        set { currentLevelTreasureCount += value; }
    }
    public int CurrentRound
    {
        get { return currentRound; }
        set { currentRound = value; }
    }
    #endregion
    public bool gameOver;
    public string winningPlayer;

    public int startingTreasureCount = 10, startingNumberOfRounds = 2;

    [HideInInspector]
    public float timer;

    float startingTime = 60f;

    float newRoundDelay = 3f;
    bool inRound;

    bool player1RoundWin, player2RoundWin;

    public void Awake()
    {
        if (controller == null)
        {
            DontDestroyOnLoad(gameObject);
            controller = this;
        }
        else if (controller != this)
        {
            Destroy(gameObject);
        }
        timer = startingTime;
        StartCoroutine(StartRounds());
    }


    void Update()
    {
        if (Player1BatteryLevel <= 0.001f)
        {
            player1RoundWin = true;
        }
        else if (Player2BatteryLevel <= 0.001f)
        {
            player2RoundWin = true;
        }

        Debug.Log(gameOver + " " + Input.GetButtonDown("EndGameReset"));
        if (gameOver && (GamepadController.controller.GetButtonDown(XInputDotNetPure.PlayerIndex.One, GamePadButton.A) || GamepadController.controller.GetButtonDown(XInputDotNetPure.PlayerIndex.Two, GamePadButton.A)))
        {
            gameOver = false;
            player1BatteryLevel = 1;
            player2BatteryLevel = 1;
            player1TreasureCount = 0;
            player2TreasureCount = 0;
            timer = startingTime;
            currentLevelTreasureCount = startingTreasureCount;
            UIController.controller.Reset();
            Application.LoadLevel("Level");
        }
    }
    IEnumerator StartRounds()
    {
        currentLevelTreasureCount = startingTreasureCount;

        timer = startingTime;
        player1RoundWin = false;
        player2RoundWin = false;
        while ((timer > 0) && !player1RoundWin && !player2RoundWin)
        {
            timer--;
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(newRoundDelay);
        Debug.Log("Round over!");

        //Check for winner
        if (player1RoundWin) winningPlayer = "Player 1";
        else if (player2RoundWin) winningPlayer = "Player 2";
        else winningPlayer = (Player1TreasureCount > Player2TreasureCount) ? "Player 1" : "Player 2";
        GameController.controller.gameOver = true;

        yield return null;
    }

}
