using UnityEngine;
using System.Collections;

public class SlopeController : MonoBehaviour {

    public GameObject initialSlope;
    public GameObject slopePrefab;

    // Maintain two chunks of slope.
    private GameObject currentSlope;
    private GameObject nextSlope;
    private float slopeLength;

	// Use this for initialization
	void Start () {
        currentSlope = null;
        nextSlope = initialSlope;
        // Getting the z length of the slope. Better than hardcoding it in.
        slopeLength = initialSlope.GetComponent<Collider>().bounds.extents.z * 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // This is called when the player hits the trigger wall.
    public void GenerateTerrain() {
        // This predicate only triggers on the first slope section.
        if (currentSlope != null) {
            Destroy(currentSlope);
        }
        currentSlope = nextSlope;
        nextSlope = GetNewSlope(currentSlope);
    }

    GameObject GetNewSlope(GameObject currentSlope) {
        Vector3 newPosition = currentSlope.transform.position + new Vector3(0, 0, slopeLength/2);
        Quaternion newRotation = currentSlope.transform.rotation;
        return Instantiate(currentSlope, newPosition, newRotation) as GameObject;
    }
}
