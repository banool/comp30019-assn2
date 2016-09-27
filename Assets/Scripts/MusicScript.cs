using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {

    AudioSource audioSource;
    public float rampUp = 0.05f;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = 0.8f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!audioSource.isPlaying) {
            audioSource.pitch += rampUp;
            audioSource.Play();
        }
    }
}
