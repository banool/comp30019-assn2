//Hugh Edwards (584183) University of Melbourne Graphics and Interaction 2016
using UnityEngine;
using System.Collections;

public class PointLight : MonoBehaviour
{

    //basic pointlight class. very similar to the lab
    public Color color;


    public Vector3 GetWorldPosition()
    {
        return this.transform.position;
    }

    void Update()
    {

    }
}

