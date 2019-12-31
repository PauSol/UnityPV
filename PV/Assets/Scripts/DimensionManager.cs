using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DimensionManager : MonoBehaviour
{
    static GameObject rgbDimension;
    static GameObject bwDimension;

    public static bool inRealDimension;
    public static bool canChangeDimension;

    public static void Init()
    {
        inRealDimension = true;
        rgbDimension = GameObject.Find("RGB");
        bwDimension = GameObject.Find("BW");

        if (bwDimension != null)
            bwDimension.SetActive(false);

        if (rgbDimension != null)
            rgbDimension.SetActive(true);

    }

    public static int ChangeDimension()
    {
        inRealDimension = !inRealDimension;
        rgbDimension.SetActive(inRealDimension);
        bwDimension.SetActive(!inRealDimension);

        if (new[] {9, 10, 11}.Contains(LayerManager.bitLayer))
        {
            LayerManager.bitLayer = 12;
            LayerManager.layerPlayer = 1 << LayerManager.bitLayer;
        } else if (new[] { 12, 13}.Contains(LayerManager.bitLayer)) {
            LayerManager.bitLayer = 9;
            LayerManager.layerPlayer = 1 << LayerManager.bitLayer;
        }
        return LayerManager.bitLayer;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerManager.layerChange)
        {
            canChangeDimension = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerManager.layerChange)
        {
            canChangeDimension = false;
        }
    }

}
