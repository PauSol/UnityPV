using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LayerManager
{
    public static int layerPlayer;
    public static int starterLayer;
    public static int maxLayer;
    public static int minLayer;
    public static int layerChange;

    public static int minLayerRGB;
    public static int maxLayerRGB;
    public static int minLayerBW;
    public static int maxLayerBW;

    public static int bitLayer;

    static bool inputPositive;

    // Start is called before the first frame update
    public static void Init()
    {
        starterLayer = 9;
        bitLayer = starterLayer;
        layerPlayer = 1 << bitLayer;

        maxLayer = 13;
        minLayer = 9;
        layerChange = 14;

        minLayerRGB = 9;
        minLayerBW = 12;
        maxLayerRGB = 11;
        maxLayerBW = 13;

    }

    public static int ChangeLayer(float input)
    {
        inputPositive = (input > 0f) ? true : false;

        bitLayer += (inputPositive == true) ? 1 : -1;

        if (DimensionManager.inRealDimension) //if RGB dimension
        {
            if (bitLayer < minLayerRGB)
                bitLayer = maxLayerRGB;
            else if (bitLayer > maxLayerRGB)
                bitLayer = minLayerRGB;
        } else if (!DimensionManager.inRealDimension) //if BW world
        {
            if (bitLayer < minLayerBW)
                bitLayer = maxLayerBW;
            else if (bitLayer > maxLayerBW)
                bitLayer = minLayerBW;
        }

        layerPlayer = 1 << bitLayer;

        return bitLayer;
    }
}
