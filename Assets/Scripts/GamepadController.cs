using UnityEngine;
using XInputDotNetPure;
using System.Collections.Generic;

class xRumble
{
    public float timer;
    public float fadeTime;
    public Vector2 power; 

    public void Update() { timer -= Time.deltaTime; }
}

public class GamepadController : MonoBehaviour
{
    public static GamepadController controller;

    GamePadState p1State, p1PrevState,
                 p2State, p2PrevState;
    List<xRumble> p1rumbleEvents;
    List<xRumble> p2rumbleEvents; 

    // Set a static reference
    void Awake()
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
        p1rumbleEvents = new List<xRumble>();
        p2rumbleEvents = new List<xRumble>();
    }

    // Poll the gamepad state, do rumbling
    void Update()
    {
        p1PrevState = p1State;
        p2PrevState = p2State;
        p1State = GamePad.GetState(PlayerIndex.One);
        p2State = GamePad.GetState(PlayerIndex.Two);
        HandleRumble();
    }

    // Rumbling implementation
    void HandleRumble()
    {
        Vector2 currentPower;
        float timeLeft;
        // Player1
        if (p1rumbleEvents.Count > 0)
        {
            currentPower = new Vector2(0, 0);
            for (int i = 0; i < p1rumbleEvents.Count; ++i)
            {
                // Update current event
                p1rumbleEvents[i].Update();

                if (p1rumbleEvents[i].timer > 0)
                {
                    // Calculate current power
                    timeLeft = Mathf.Clamp(p1rumbleEvents[i].timer / p1rumbleEvents[i].fadeTime, 0f, 1f);
                    currentPower = new Vector2(Mathf.Max(p1rumbleEvents[i].power.x * timeLeft, currentPower.x),
                                               Mathf.Max(p1rumbleEvents[i].power.y * timeLeft, currentPower.y));

                    // Apply vibration to gamepad motors
                    GamePad.SetVibration(PlayerIndex.One, currentPower.x, currentPower.y);
                }
                else
                {
                    // Remove expired event
                    p1rumbleEvents.Remove(p1rumbleEvents[i]);
                }
            }
        }

        // Player 2
        if (p2rumbleEvents.Count > 0)
        {
            currentPower = new Vector2(0, 0);
            for (int i = 0; i < p2rumbleEvents.Count; ++i)
            {
                // Update current event
                p2rumbleEvents[i].Update();

                if (p2rumbleEvents[i].timer > 0)
                {
                    // Calculate current power
                    timeLeft = Mathf.Clamp(p2rumbleEvents[i].timer / p2rumbleEvents[i].fadeTime, 0f, 1f);
                    currentPower = new Vector2(Mathf.Max(p2rumbleEvents[i].power.x * timeLeft, currentPower.x),
                                               Mathf.Max(p2rumbleEvents[i].power.y * timeLeft, currentPower.y));

                    // Apply vibration to gamepad motors
                    GamePad.SetVibration(PlayerIndex.Two, currentPower.x, currentPower.y);
                }
                else
                {
                    // Remove expired event
                    p2rumbleEvents.Remove(p2rumbleEvents[i]);
                }
            }
        }
    }

    // Add a rumble event
    public void AddRumble(PlayerIndex player, float timer, Vector2 power, float fadeTime = 0f)
    {

        xRumble rumble = new xRumble();
        switch (player)
        {
            case PlayerIndex.One:
                rumble.timer = timer;
                rumble.power = power;
                rumble.fadeTime = fadeTime;
                p1rumbleEvents.Add(rumble);
                break;
            case PlayerIndex.Two:
                rumble.timer = timer;
                rumble.power = power;
                rumble.fadeTime = fadeTime;
                p1rumbleEvents.Add(rumble);
                break;
            default: break;
        }
    }

    // Get button down event
    public bool GetButtonDown(PlayerIndex player, GamePadButton button)
    {
        switch (player)
        {
            case PlayerIndex.One:
                switch (button)
                {
                    case GamePadButton.Guide: return p1PrevState.Buttons.Guide == ButtonState.Released && p1State.Buttons.Guide == ButtonState.Pressed;
                    case GamePadButton.A: return p1PrevState.Buttons.A == ButtonState.Released && p1State.Buttons.A == ButtonState.Pressed;
                    case GamePadButton.B: return p1PrevState.Buttons.B == ButtonState.Released && p1State.Buttons.B == ButtonState.Pressed;
                    case GamePadButton.X: return p1PrevState.Buttons.X == ButtonState.Released && p1State.Buttons.X == ButtonState.Pressed;
                    case GamePadButton.Y: return p1PrevState.Buttons.Y == ButtonState.Released && p1State.Buttons.Y == ButtonState.Pressed;
                    case GamePadButton.L_Stick: return p1PrevState.Buttons.LeftStick == ButtonState.Released && p1State.Buttons.LeftStick == ButtonState.Pressed;
                    case GamePadButton.R_Stick: return p1PrevState.Buttons.RightStick == ButtonState.Released && p1State.Buttons.RightStick == ButtonState.Pressed;
                    case GamePadButton.L_Trigger: return p1PrevState.Triggers.Left == 0.0f && p1State.Triggers.Left >= 0.1f;
                    case GamePadButton.R_Trigger: return p1PrevState.Triggers.Right == 0.0f && p1State.Triggers.Right >= 0.1f;
                    case GamePadButton.L_Bumper: return p1PrevState.Buttons.LeftShoulder == ButtonState.Released && p1State.Buttons.LeftShoulder == ButtonState.Pressed;
                    case GamePadButton.R_Bumper: return p1PrevState.Buttons.RightShoulder == ButtonState.Released && p1State.Buttons.RightShoulder == ButtonState.Pressed;
                    default: return false;
                }
            case PlayerIndex.Two:
                switch (button)
                {
                    case GamePadButton.Guide: return p2PrevState.Buttons.Guide == ButtonState.Released && p2State.Buttons.Guide == ButtonState.Pressed;
                    case GamePadButton.A: return p2PrevState.Buttons.A == ButtonState.Released && p2State.Buttons.A == ButtonState.Pressed;
                    case GamePadButton.B: return p2PrevState.Buttons.B == ButtonState.Released && p2State.Buttons.B == ButtonState.Pressed;
                    case GamePadButton.X: return p2PrevState.Buttons.X == ButtonState.Released && p2State.Buttons.X == ButtonState.Pressed;
                    case GamePadButton.Y: return p2PrevState.Buttons.Y == ButtonState.Released && p2State.Buttons.Y == ButtonState.Pressed;
                    case GamePadButton.L_Stick: return p2PrevState.Buttons.LeftStick == ButtonState.Released && p2State.Buttons.LeftStick == ButtonState.Pressed;
                    case GamePadButton.R_Stick: return p2PrevState.Buttons.RightStick == ButtonState.Released && p2State.Buttons.RightStick == ButtonState.Pressed;
                    case GamePadButton.L_Trigger: return p2PrevState.Triggers.Left == 0.0f && p2State.Triggers.Left >= 0.1f;
                    case GamePadButton.R_Trigger: return p2PrevState.Triggers.Right == 0.0f && p2State.Triggers.Right >= 0.1f;
                    case GamePadButton.L_Bumper: return p2PrevState.Buttons.LeftShoulder == ButtonState.Released && p2State.Buttons.LeftShoulder == ButtonState.Pressed;
                    case GamePadButton.R_Bumper: return p2PrevState.Buttons.RightShoulder == ButtonState.Released && p2State.Buttons.RightShoulder == ButtonState.Pressed;
                    default: return false;
                }
            default: return false;
        }
    }

    // Get left stick
    public Vector2 GetLeftStick(PlayerIndex player)
    {
        switch (player)
        {
            case PlayerIndex.One: return new Vector2(p1State.ThumbSticks.Left.X, p1State.ThumbSticks.Left.Y);
            case PlayerIndex.Two: return new Vector2(p2State.ThumbSticks.Left.X, p2State.ThumbSticks.Left.Y);
            default: return new Vector2(0f, 0f);
        }
    }
}
