//Hugh Edwards (584183) University of Melbourne Graphics and Interaction 2016
using UnityEngine;
using System.Collections;

public class WaterScript : MonoBehaviour {


    // Water script - passes in stuff to shader
    public Shader shader;
    public PointLight sun;

    private MeshRenderer rend;

    void Start()
    {
 
        rend = GetComponent<MeshRenderer>();
        rend.material.shader = shader;

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Color[] colors = new Color[vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
            colors[i] = new Color (0.2F, 0.3F, 0.5F, 0.7F);

        mesh.colors = colors;
    }


    void Update()
    {
        rend.material.SetColor("_PointLightColor", sun.color);
        rend.material.SetVector("_PointLightPosition", sun.GetWorldPosition());
    }

    void OnCollisionEnter(Collision other)
    {
       if (other.gameObject.tag == "player") {
            GameObject.Find("Canvas/GameOver").GetComponent<GameOverScript>().EndGame();
       }

    }


}
