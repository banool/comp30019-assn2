﻿using UnityEngine;
using System.Collections;

public class FogController : MonoBehaviour {

    public Color fogColor = Color.green;
    public float fogDensity;

    void Start()
    {
        RenderSettings.fog = true;
        RenderSettings.fogColor = fogColor;
        RenderSettings.fogDensity = fogDensity;
    }

}
