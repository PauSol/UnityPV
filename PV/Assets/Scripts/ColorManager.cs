using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorManager
{
    public static Color[] colors;
    public static Color[] colorsAlpha;
    public static int maxColors;

    static int color;
    static int minColorRGB;
    static int maxColorRGB;
    static int minColorBW;
    static int maxColorBW;

    static bool inputPositive;

    public static void InitColors()
    {
        color = 0;
        colors = new Color[5];
        colorsAlpha = new Color[5];

        colors[0] = Color.red;
        colors[1] = Color.green;
        colors[2] = Color.blue;
        colors[3] = Color.black;
        colors[4] = Color.white;

        colorsAlpha[0] = new Color(255f, 0f, 0f, 255f / 2f);
        colorsAlpha[0] = new Color(0f, 255f, 0f, 255f / 2f);
        colorsAlpha[0] = new Color(0f, 0f, 255f, 255f / 2f);
        colorsAlpha[0] = new Color(0, 0f, 0f, 255f / 2f);
        colorsAlpha[0] = new Color(255f, 255f, 255f, 255f / 2f);
        
        maxColors = colors.Length;

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
        color = 0;
        return colors[color];
    }
    public static Color changeToBlack()
    {
        color = 3;
        return colors[color];
    }

    //public static void changePlatformsToAlpha()
    //{
    //    if (LayerManager.bitLayer - 9 == color)
    //    {
            
    //    }
    //}

}
