using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorManager
{
    public static List<Color> colors;
    public static int maxColors;

    static int color;
    static int minColorRGB;
    static int maxColorRGB;
    static int minColorBW;
    static int maxColorBW;

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

        minColorRGB = 0;
        maxColorRGB = 2;
        minColorBW = 3;
        maxColorBW = 4;
    }

    public static Color ChangeColor(float input)
    {
        inputPositive = (input > 0f) ? true : false;

        color += (inputPositive == true) ? 1 : -1;
        
        if (DimensionManager.inRealDimension) //if RGB dimension
        {
            if (color < minColorRGB)
                color = maxColorRGB;
            else if (color > maxColorRGB)
                color = minColorRGB;
        } else if (!DimensionManager.inRealDimension) // if BW dimension
        {
            if (color < minColorBW)
                color = maxColorBW;
            else if (color > maxColorBW)
                color = minColorBW;
        }

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
