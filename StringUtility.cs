using System;

public static class StringUtility
{
    public static bool IsInteger(string input)
    {
        if (int.TryParse(input, out int parsedNumber))
        {
            return parsedNumber >= 0 && parsedNumber <= 9;
        }
        else
        {
            return false;
        }
    }
}