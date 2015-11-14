using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController controller;

    public Slider p1Battery,
                  p2Battery;

    public Text p1Score,
                p2Score,
                timeLeft,
                gemsLeft,
                gameOver,
                playAgain;

    public Image playAgainButton;
    
    void Awake()
    {
        if (controller = null)
        {
            DontDestroyOnLoad(gameObject);
            controller = this;
        }
        else if (controller != this)
        {
            Destroy(gameObject);
        }
        Reset();
    }

    void Update()
    {
        //if (GameController.controller.gameOver)
        //{
            //timeLeft.gameObject.SetActive(false);
            //gemsLeft.gameObject.SetActive(false);
            //gameOver.text = "Player " + GameController.controller.winner + " wins!";
            //gameOver.gameObject.SetActive(true);
            //playAgain.gameObject.SetActive(true);
            //playAgainButton.gameObject.SetActive(true);
        //}
        //else 
        //{
            UpdateTime();
            UpdateGemsLeft();
            UpdateScore();
            UpdateBattery();
        //}
    }

    public void Reset()
    {
        p1Battery.gameObject.SetActive(true);
        p1Score.gameObject.SetActive(true);
        p2Battery.gameObject.SetActive(true);
        p2Score.gameObject.SetActive(true);
        timeLeft.gameObject.SetActive(true);
        gemsLeft.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
        playAgain.gameObject.SetActive(false);
        playAgainButton.gameObject.SetActive(false);
    }

    public void UpdateTime()
    {
        //timeLeft.text = GameController.controller.TimeLeft;
    }

    public void UpdateGemsLeft()
    {
        //gemsLeft.text = GameController.controller.GemsLeft + " Left";
    }

    public void UpdateScore()
    {
        //p1Score.text = GameController.controller.p1Gems;
        //p2Score.text = GameController.controller.p2Gems;
    }

    public void UpdateBattery()
    {
        //p1Battery.value = GameController.controller.p1Battery;
        //p2Battery.value = GameController.controller.p2Battery;
    }
}
