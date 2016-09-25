using UnityEngine;
using System.Collections;

public class WelcomeCameraController : MonoBehaviour {

    /*
     * Ignore this for now, doesn't work how I was imagining.
     */

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    public float lookSpeed = 0.01F;
    private Vector3 target;

    // Use this for initialization
    void Start () {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void lookAtMenuItem(GameObject MenuItem) {
        target = MenuItem.transform.position;
        //transform.LookAt(MenuItem.transform);
    }

    public void resetTransform() {
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
}
