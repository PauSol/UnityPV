using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Renderer rend;
    // Start is called before the first frame update
    Vector3 initPos;


    Image colorBefore;
    Image colorAfter;
    
    void Awake()
    {
        LayerManager.Init();
        ColorManager.InitColors();
        DimensionManager.Init();

        rend = GetComponent<Renderer>();
        rend.material.color = ColorManager.colors[0];
        gameObject.layer = LayerManager.starterLayer;

        colorBefore = GameObject.Find("QColor").GetComponent<Image>();
        colorAfter = GameObject.Find("EColor").GetComponent<Image>();

        initPos = transform.position;

    }

    void Update()
    {
        colorBefore.color = ColorManager.ColorBefore();
        colorAfter.color = ColorManager.ColorAfter();
    }

    public void Restart()
    {
        transform.position = initPos;
        rend.material.color = ColorManager.colors[0];
        gameObject.layer = LayerManager.starterLayer;

        if (!DimensionManager.inRealDimension)
            DimensionManager.inRealDimension = true;
    }

 
}
