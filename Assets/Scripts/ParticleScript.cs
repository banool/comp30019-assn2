using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour
{

    //Simple script - camera follows ball

    public GameObject following;

    public int BurstNumber;

    private Vector3 offset;

    private ParticleSystem p;

    void Start()
    {
        offset = transform.position - following.transform.position;
        p = GetComponent<ParticleSystem>();
        p.Play();
        p.emissionRate = 0;

    }

    void Update()
    {
        transform.position = following.transform.position + offset;

        if (Input.GetKeyDown("space")) {
            p.Emit(BurstNumber);
            
        }

    }

   

}