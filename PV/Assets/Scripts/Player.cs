using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Renderer rend;
    // Start is called before the first frame update

    
    void Awake()
    {
        LayerManager.Init();
        ColorManager.InitColors();
        DimensionManager.Init();

        rend = GetComponent<Renderer>();
        rend.material.color = ColorManager.colors[0];
        gameObject.layer = LayerManager.starterLayer;

    }

 
}
