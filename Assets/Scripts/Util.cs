using Unity.VisualScripting;
using UnityEngine;

public static class Util
{
    public static Color GetColor()
    {
        return Color.white;
    }

    public static Color GetColorRGBA()
    {
        return new Color(156, 117, 234, 255);
    }

    public static Color GetColorFromHexaDecimal(string _hexColor)
    {
        if (UnityEngine.ColorUtility.TryParseHtmlString(_hexColor, out Color myColor))
        {
            return myColor;
        }
        else
        {
            Debug.LogError("hex = " + _hexColor);
            return Color.white;
        }
    }
}
