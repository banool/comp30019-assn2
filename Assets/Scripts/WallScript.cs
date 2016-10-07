﻿//Hugh Edwards (584183) University of Melbourne Graphics and Interaction 2016
using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {

    //slope script - passes stuff to shader

    public Shader shader;
    public PointLight light; //TODO im not sure this does anything?

    public float speed = 0;

    void Start()
    {
 
        MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();
        renderer.material.shader = shader;

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Color[] colors = new Color[vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
            colors[i] = new Color (0.5F, 0.5F, 0.5F, 1.0F);

        mesh.colors = colors;

    }


    void Update()
    {

        MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();

        renderer.material.SetColor("_PointLightColor", this.light.color);
        renderer.material.SetVector("_PointLightPosition", this.light.GetWorldPosition());
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "player")
        {
            GameObject.Find("Canvas/GameOver").GetComponent<GameOverScript>().EndGame();
        }

    }

}
