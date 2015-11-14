using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class Treasure : MonoBehaviour
{
    SpriteRenderer sr;
    public FlashlightColor currentColor = FlashlightColor.Red;
    public bool visible;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (visible)
        {
            sr.enabled = true;
        }
        else
        {
            sr.enabled = false;
        }
    }

    public void Show()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!visible) return;
            Debug.Log("Treasure collected!");
            gameObject.SetActive(false);
            if (other.GetComponent<Player>().currentIndex == XInputDotNetPure.PlayerIndex.One)
            {
                GameController.controller.Player1TreasureCount = 1;
            }
            else
            {
                GameController.controller.Player2TreasureCount = 1;
            }
            GameController.controller.CurrentLevelTreasureCount = -1;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Flashlight")
        {
            if (other.GetComponentInParent<Flashlight>().currentColor == currentColor)
            {
                visible = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Flashlight")
        {
                visible = false;
        }
    }

    public void SetColor(FlashlightColor color, Sprite s)
    {
        currentColor = color;
        sr.sprite = s;
    }
}
