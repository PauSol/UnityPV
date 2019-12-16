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

        //RGB world
        if (bitLayer < minLayer)
            bitLayer = maxLayer;
        else if (bitLayer > maxLayer)
            bitLayer = minLayer;

        layerPlayer = 1 << bitLayer;

        return bitLayer;
    }
}
