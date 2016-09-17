using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    //Simple script - camera follows ball

    public GameObject following;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - following.transform.position;
    }

    void Update()
    {
        transform.position = following.transform.position + offset;
    }
}