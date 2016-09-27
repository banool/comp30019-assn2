using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour
{

    //Simple script - camera follows ball

    public PlayerController following;

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
        // TODO why the hell doesn't this work.
        // The if statement says if it is in the air, it shouldnt emit more particles 
        // when space is pressed, but it does anyway.
        if (Input.GetKeyDown("space") && !following.onGround) {
           // p.Emit(BurstNumber);
        }
    }

   

}