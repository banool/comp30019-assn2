﻿using UnityEngine;
using System.Collections;

public class TreeScript : MonoBehaviour {

    //slope script - passes stuff to shader

    public Shader shader;
    private PointLight plight; //TODO im not sure this does anything?

    public float treeHitPenalty = 50.0f;

    MeshRenderer rend;

    void Start() {

        plight = GameObject.Find("Main Camera/PointLight").GetComponent<PointLight>();

        rend = GetComponent<MeshRenderer>();
        rend.material.shader = shader;

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Color[] colors = new Color[vertices.Length];

        // This doesn't even do anything TODO, it is overwritten in update.
        for (int i = 0; i < vertices.Length; i++)
            colors[i] = new Color(0.5F, 0.5F, 0.5F, 1.0F);

        mesh.colors = colors;

    }

    void Update() {
        rend.material.SetColor("_PointLightColor", plight.color);
        rend.material.SetVector("_PointLightPosition", plight.GetWorldPosition());
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "player") {
            GameObject.Find("Canvas/Score").GetComponent<DisplayScript>().reduceScore(treeHitPenalty);
        }

    }

}
