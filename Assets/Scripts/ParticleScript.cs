using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour
{
    public int BurstNumber;
    private ParticleSystem p;

    void Start()
    {
        p = GetComponent<ParticleSystem>();
        p.Play();
        p.emissionRate = 0;
    }
}