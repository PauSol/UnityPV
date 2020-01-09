using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesHolder : MonoBehaviour
{
    public static ParticleSystem.MainModule jumpMain;
    public GameObject changeColorParticle;
    public GameObject changeDimensionParticle;

    void Start()
    {
        jumpMain = changeColorParticle.GetComponent<ParticleSystem>().main;
    }

}
