using UnityEngine;
using System.Collections;


public class Flashlight : MonoBehaviour
{
    public static int numberOfColors = 5;

    public FlashlightColor currentColor;
    public SpriteRenderer flashlightRing;
    public CircleCollider2D flashlightCollider;

    float deadBatteryIncrement = 0.001f;
    [HideInInspector]
    public XInputDotNetPure.PlayerIndex currentIndex;

    float startingAlpha;

    void Awake()
    {
        startingAlpha = flashlightRing.color.a;
    }
    void Update()
    {
        if (currentColor != FlashlightColor.White)
        {
            if (currentIndex == XInputDotNetPure.PlayerIndex.One)
            {
                GameController.controller.Player1BatteryLevel = -deadBatteryIncrement;
            }
            else
            {
                GameController.controller.Player2BatteryLevel = -deadBatteryIncrement;
            }
        }

        if (currentIndex == XInputDotNetPure.PlayerIndex.One)
        {
            if (GameController.controller.Player1BatteryLevel <= deadBatteryIncrement)
            {
                GoToColor(FlashlightColor.White);
                return;
            }
        }
        if (currentIndex == XInputDotNetPure.PlayerIndex.Two)
        {
            if (GameController.controller.Player2BatteryLevel <= deadBatteryIncrement)
            {
                GoToColor(FlashlightColor.White);
                return;
            }
        }
        if (GamepadController.controller.GetButtonDown(currentIndex, GamePadButton.R_Bumper) ||
            GamepadController.controller.GetButtonDown(currentIndex, GamePadButton.L_Bumper))
        {
            GoToColor(FlashlightColor.White);
        }
        else if (GamepadController.controller.GetButtonDown(currentIndex, GamePadButton.R_Trigger))
        {
            CycleColors(true);
        }
        else if (GamepadController.controller.GetButtonDown(currentIndex, GamePadButton.L_Trigger))
        {
            CycleColors(false);
        }
        else if (GamepadController.controller.GetButtonDown(currentIndex, GamePadButton.A))
        {
            GoToColor(FlashlightColor.Green);
        }
        else if (GamepadController.controller.GetButtonDown(currentIndex, GamePadButton.B))
        {
            GoToColor(FlashlightColor.Red);
        }
        else if (GamepadController.controller.GetButtonDown(currentIndex, GamePadButton.X))
        {
            GoToColor(FlashlightColor.Blue);
        }
        else if (GamepadController.controller.GetButtonDown(currentIndex, GamePadButton.Y))
        {
            GoToColor(FlashlightColor.Yellow);
        }
    }

    public void GoToColor(FlashlightColor color)
    {
        //Set flashlight to color
        currentColor = color;
        ChangeColor();
    }

    public void CycleColors(bool cycleToRight)
    {
        int cur = (int)currentColor;
        if (cycleToRight)
        {
            cur++;
            if (cur >= numberOfColors) cur = 0;
        }
        else
        {
            cur--;
            if (cur < 0) cur = numberOfColors - 1;
        }
        currentColor = (FlashlightColor)cur;
        ChangeColor();
    }

    public void ChangeColor()
    {
        flashlightRing.color = GetColor(currentColor);
    }

    Color GetColor(FlashlightColor color)
    {
        Color c = Color.white;
        switch (color)
        {
            default:
            case FlashlightColor.White: c = Color.white; break;
            case FlashlightColor.Red: c = Color.red; break;
            case FlashlightColor.Blue: c = Color.blue; break;
            case FlashlightColor.Green: c = Color.green; break;
            case FlashlightColor.Yellow: c = Color.yellow; break;
        }
        c.a = startingAlpha;
        return c;
    }
}
