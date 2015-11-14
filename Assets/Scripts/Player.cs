using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    PlayerMovement movement;
    Vector2 position;
    [HideInInspector]
    public XInputDotNetPure.PlayerIndex currentIndex;

    Flashlight flashlight;

    void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        //Extract the player index from the name of player
        if (this.name == "Player1") currentIndex = XInputDotNetPure.PlayerIndex.One;
        else if (this.name == "Player2") currentIndex = XInputDotNetPure.PlayerIndex.Two;

        flashlight = GetComponent<Flashlight>();
        flashlight.currentIndex = currentIndex;
    }

    void Update()
    {
        //position.x = Input.GetAxisRaw("Horizontal");
        //position.y = Input.GetAxisRaw("Vertical");

        position = GamepadController.controller.GetLeftStick(currentIndex);
    }

    void FixedUpdate()
    {
        if (position.x != 0 || position.y != 0) movement.Move(position);
        else movement.Idle();
    }
}
