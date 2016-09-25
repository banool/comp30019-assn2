using UnityEngine;
using System.Collections;

public class TerrainTriggerWall : MonoBehaviour {

    public SlopeController slopeController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter() {
        print("hey");
        slopeController.GenerateTerrain();
    }
}
