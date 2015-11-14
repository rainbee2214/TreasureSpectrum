using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    PlayerMovement movement;
    Vector2 position;
    XInputDotNetPure.PlayerIndex currentIndex;

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
        movement.Move(position);
    }
}
