using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController controller;

    #region Properties
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

    float startingTime = 30f;

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
        CurrentLevelTreasureCount = startingTreasureCount;
        timer = startingTime;
        StartCoroutine(StartRounds());
    }


    void Update()
    {
        if (Player1TreasureCount >= startingTreasureCount / 5)
        {
            player1RoundWin = true;
        }
        else if (Player2TreasureCount >= startingTreasureCount / 5)
        {
            player2RoundWin = true;
        }
    }
    IEnumerator StartRounds()
    {
        CurrentLevelTreasureCount = startingTreasureCount;
        //Start a new round 
        for (int roundNo = 1; roundNo < startingNumberOfRounds; roundNo++)
        {
            //Generate treasure and place it (using treasure controller)
            //Place players in starting locations
            //start timer
            while ((timer > 0) && !player1RoundWin && !player2RoundWin)
            {
                timer--;
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForSeconds(newRoundDelay);
        }
        //-generate treasure, start time limit
        //if treasure if collected enough or time is over ->start next round
        yield return null;
    }

}
