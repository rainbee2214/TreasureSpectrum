using UnityEngine;
using System.Collections;

public enum FlashlightColor
{
    Red, 
    Blue,
    Green,
    Yellow
}
public class Flashlight : MonoBehaviour
{
    public static int numberOfColors = 4;

    public FlashlightColor currentColor;
  
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
    }
    public void CycleColors(bool cycleToRight)
    {
        //Set flashlight to next color on list
        if (cycleToRight) currentColor = (FlashlightColor)(currentColor++);
        else currentColor = (FlashlightColor)(currentColor--);

        if ((int)currentColor >= numberOfColors) currentColor = (FlashlightColor)0;
        else if ((int)currentColor <= 0) currentColor = (FlashlightColor)(numberOfColors - 1);
    }
}
