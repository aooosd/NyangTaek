using Unity.VisualScripting;
using UnityEngine;

/// <summary>색상 변환처럼 여러 클래스에서 재사용할 보조 기능을 제공합니다.</summary>
public static class Util
{
    /// <summary>기본 색상인 흰색을 반환합니다.</summary>
    public static Color GetColor()
    {
        return Color.white;
    }

    /// <summary>프로젝트에서 사용하는 기본 RGBA 색상을 반환합니다.</summary>
    public static Color GetColorRGBA()
    {
        return new Color(156, 117, 234, 255);
    }

    /// <summary>16진수 색상 문자열을 Unity Color 값으로 변환합니다.</summary>
    /// <param name="_hexColor">#RRGGBB 또는 #RRGGBBAA 형식의 문자열입니다.</param>
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
<<<<<<< Updated upstream
}
=======
}

>>>>>>> Stashed changes
