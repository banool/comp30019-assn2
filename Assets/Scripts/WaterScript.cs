//Hugh Edwards (584183) University of Melbourne Graphics and Interaction 2016
using UnityEngine;
using System.Collections;

public class WaterScript : MonoBehaviour {


    //Water script - passes in stuff to shader

    public Shader shader;
    public PointLight sun;

    // Needs this to follow the player
    public PlayerController player;
    private float offset;

    void Start()
    {
 
        MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();
        renderer.material.shader = shader;

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Color[] colors = new Color[vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
            colors[i] = new Color (0.2F, 0.3F, 0.5F, 0.5F);

        mesh.colors = colors;

        offset = transform.position.z - player.transform.position.z;
    }


    void Update()
    {

        MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();

        renderer.material.SetColor("_PointLightColor", this.sun.color);
        renderer.material.SetVector("_PointLightPosition", this.sun.GetWorldPosition());

        transform.position = new Vector3(0.0f, 0.0f, (player.transform.position.z + offset));
    }

    void OnCollisionEnter(Collision other)
    {
       if (other.gameObject.tag == "player") {
            GameObject.Find("Canvas/GameOver").GetComponent<GameOverScript>().EndGame();
       }

    }


}
