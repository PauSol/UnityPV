using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorManager
{
    public static List<Color> colors;
    public static int maxColors;

    static int color;

    static bool inputPositive;

    public static void InitColors()
    {
        colors = new List<Color>();

        colors.Add(Color.red);
        colors.Add(Color.green);
        colors.Add(Color.blue);
        colors.Add(Color.black);
        colors.Add(Color.white);
        
        maxColors = colors.Count;

    }

    public static Color ChangeColor(float input)
    {
        inputPositive = (input > 0f) ? true : false;

        color += (inputPositive == true) ? 1 : -1;

        if (color < 0)
            color = maxColors - 1;
        else if (color >= maxColors)
            color = 0;

        return colors[color];
    }

    public static Color changeToRed()
    {
        return colors[0];
    }
    public static Color changeToBlack()
    {
        return colors[3];
    }

}
