using UnityEngine;
using System.Collections;

public enum FlashlightColor
{
    Red,
    Blue,
    Green,
    Yellow,
    White
}
public class Flashlight : MonoBehaviour
{
    public static int numberOfColors = 5;

    public FlashlightColor currentColor;
    public SpriteRenderer flashlightRing;

    [HideInInspector]
    public XInputDotNetPure.PlayerIndex currentIndex;

    void Update()
    {
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

    public void TurnFlashLightOn()
    {

    }

    public void TurnFlashlightOff()
    {

    }

    public void GoToColor(FlashlightColor color)
    {
        //Set flashlight to color
        currentColor = color;
        ChangeColor();
    }

    public void CycleColors(bool cycleToRight)
    {
        //Set flashlight to next color on list
        //if (cycleToRight) currentColor = (FlashlightColor)(currentColor++);
        //else currentColor = (FlashlightColor)(currentColor--);

        ////if ((int)currentColor >= numberOfColors) currentColor = (FlashlightColor)0;
        ////else if ((int)currentColor <= 0) currentColor = (FlashlightColor)(numberOfColors - 1);

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
        switch (color)
        {
            default:
            case FlashlightColor.White: return Color.white;
            case FlashlightColor.Red: return Color.red;
            case FlashlightColor.Blue: return Color.blue;
            case FlashlightColor.Green: return Color.green;
            case FlashlightColor.Yellow: return Color.yellow;
        }
    }
}
