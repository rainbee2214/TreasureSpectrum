using UnityEngine;
using UnityEngine.UI;

public class BatteryColor : MonoBehaviour
{
    public Image fillImage;
    public Color red, yellow, green;
	public void UpdateColor(float val)
    {
        Debug.Log("val changed " + val);
        Color min, max;
        float lerp;
        if (val <= 0.5f)
        {
            min = red;
            max = yellow;
            lerp = val / 0.5f;
        }
        else
        {
            min = yellow;
            max = green;
            lerp = (val - 0.5f) / 0.5f;
        }
        fillImage.color = Color.Lerp(min, max, lerp);
    }
}

