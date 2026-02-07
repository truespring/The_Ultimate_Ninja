using UnityEngine;

public static class NumberFomatter
{
    public static string ToAbbreviatedString(int number)
    {
        if (number < 1000) return number.ToString("N0");
        if (number < 1000000) return (number / 1000).ToString("F1") + "K";
        return (number / 1000000).ToString("F1") + "M";
    }
}
