using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextureApplier : MonoBehaviour
{
    public Shader shader;
    public Texture diffuseMap;
    public Texture normalMap;
    public PointLight[] pointLights;

    public float amb = 3.0f;
    public float diff = 3.0f;
    public float spec = 0.15f;
    public float specn = 15.0f;

    MeshRenderer rend;

    private const int MAX_LIGHTS = 10;

    void Start() {

        rend = GetComponent<MeshRenderer>();
        rend.material.shader = shader;
        rend.material.mainTexture = diffuseMap;
        rend.material.SetTexture("_NormalMapTex", normalMap);

        rend.material.SetFloat("_AmbientCoeff", amb);
        rend.material.SetFloat("_DiffuseCoeff", diff);
        rend.material.SetFloat("_SpecularCoeff", spec);
        rend.material.SetFloat("_SpecularPower", specn);
    }

    void Update() {
        Vector3[] lightPositions = new Vector3[this.pointLights.Length];
        Color[] lightColors = new Color[this.pointLights.Length];

        for (int i = 0; i < this.pointLights.Length; i++)
        {
            lightPositions[i] = this.pointLights[i].GetWorldPosition();
            lightColors[i] = this.pointLights[i].color;
        }

        if (this.pointLights.Length <= MAX_LIGHTS)
        {
            rend.material.SetInt("_NumPointLights", this.pointLights.Length);
            PassArrayToShader.Vector3(rend.material, "_PointLightPositions", lightPositions);
            PassArrayToShader.Color(rend.material, "_PointLightColors", lightColors);
        }
    }
}
