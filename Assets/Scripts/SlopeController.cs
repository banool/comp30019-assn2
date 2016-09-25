using UnityEngine;
using System.Collections;

public class SlopeController : MonoBehaviour {

    // Maintain two chunks of slope.
    private GameObject currentSlope;
    private GameObject nextSlope;

    public GameObject initialSlope;
    public GameObject slopePrefab;

    public PlayerController player;

	// Use this for initialization
	void Start () {
        currentSlope = null;
        nextSlope = initialSlope;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // This is called when the player hits the trigger wall.
    public void GenerateTerrain() {
        // This predicate only triggers on the first triggering.
        if (currentSlope != null) {
            print("watup");
            Destroy(currentSlope);
        }
        print("yo");
        currentSlope = nextSlope;
        print("bro");
        nextSlope = GetNewSlope(currentSlope);
    }

    GameObject GetNewSlope(GameObject currentSlope) {
        Vector3 newPosition = currentSlope.transform.position + new Vector3(0, -17, 47);
        Quaternion newRotation = currentSlope.transform.rotation;
        return Instantiate(currentSlope, newPosition, newRotation) as GameObject;
    }
}
