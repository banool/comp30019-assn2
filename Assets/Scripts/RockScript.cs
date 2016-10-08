//Hugh Edwards (584183) University of Melbourne Graphics and Interaction 2016
using UnityEngine;
using System.Collections;

public class RockScript : MonoBehaviour {

    //slope script - passes stuff to shader

    public Shader shader;

    private PointLight plight; //TODO im not sure this does anything?
    private MeshRenderer rend;

    public float speed = 0;

    void Start()
    {
 
        rend = GetComponent<MeshRenderer>();
        rend.material.shader = shader;

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Color[] colors = new Color[vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
            colors[i] = new Color (0.5F, 0.5F, 0.5F, 1.0F);

        mesh.colors = colors;
        
    }

    void Update()
    {

        rend.material.SetColor("_PointLightColor", plight.color);
        rend.material.SetVector("_PointLightPosition", plight.GetWorldPosition());
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "player")
        {
            GameObject.Find("Canvas/GameOver").GetComponent<GameOverScript>().EndGame();
        }

    }

    // This should be called when instantiating the object.
    public void SetPLight(PointLight plight) {
        this.plight = plight;
    }

}
