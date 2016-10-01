using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {

    public PlayerController player;
    public float rampUp = 0.004f;
    public float startPitch = 0.8f;
    float offset;

    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = startPitch;
        offset = player.GetComponent<Rigidbody>().velocity.magnitude;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!audioSource.isPlaying) {
            audioSource.pitch = startPitch + (player.GetComponent<Rigidbody>().velocity.magnitude - offset) * rampUp;
            audioSource.Play();
        }
    }
}
