using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextureApplier : MonoBehaviour
{
    public Shader shader;
    public Texture diffuseMap; // This is just our regular texture (more aptly named)
    public Texture normalMap;
    public PointLight[] pointLights;

    public float amb = 3.0f;
    public float diff = 3.0f;
    public float spec = 0.15f;
    public float specn = 15.0f;

    MeshRenderer rend;

    private const int MAX_LIGHTS = 10;

    // Use this for initialization
    void Start() {
        // Add a MeshRenderer component. This component actually renders the mesh that
        // is defined by the MeshFilter component.
        rend = GetComponent<MeshRenderer>();
        rend.material.shader = shader;
        rend.material.mainTexture = diffuseMap;
        rend.material.SetTexture("_NormalMapTex", normalMap);

        // Extension task: set parameters appropriately for a brick wall
        rend.material.SetFloat("_AmbientCoeff", amb);
        rend.material.SetFloat("_DiffuseCoeff", diff);
        rend.material.SetFloat("_SpecularCoeff", spec);
        rend.material.SetFloat("_SpecularPower", specn);
    }

    // Called each frame
    void Update() {
        // Pass updated light positions to shader
        Vector3[] lightPositions = new Vector3[this.pointLights.Length];
        Color[] lightColors = new Color[this.pointLights.Length];
        for (int i = 0; i < this.pointLights.Length; i++) {
            lightPositions[i] = this.pointLights[i].GetWorldPosition();
            lightColors[i] = this.pointLights[i].color;
        }

        // Note: We need to be careful since we only have a fixed amount of memory
        // for the light sources in the shader (MAX_LIGHTS). It's easily possible to
        // overflow it if the pointLights array has more than MAX_LIGHTS, so might be 
        // worth doing an extra check like below. The only issue is if we change
        // MAX_LIGHTS in the shader, it also has to be correspondingly changed in 
        // this script.
        if (this.pointLights.Length > MAX_LIGHTS) {
            Debug.LogError("Number of lights exceeds the maximum shader limit");
        } else {
            // Pass the actual number of lights to the shader
            rend.material.SetInt("_NumPointLights", this.pointLights.Length);

            // Incomplete code for Unity 5.4.
            //rend.material.SetColorArray("_PointLightColors", lightColors);
            //rend.material.SetVectorArray("_PointLightPositions", new Vector4(lightPositions));

            // For Unity 5.3 and below; Unity 5.4 and above provides an array passing interface
            // via the material class itself (like SetInt() above)
            PassArrayToShader.Vector3(rend.material, "_PointLightPositions", lightPositions);
            PassArrayToShader.Color(rend.material, "_PointLightColors", lightColors);
        }
    }
}
