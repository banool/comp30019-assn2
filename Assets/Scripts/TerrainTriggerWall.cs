using UnityEngine;
using System.Collections;

public class TerrainTriggerWall : MonoBehaviour {

    public SlopeController slopeController;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "player") { 
            slopeController.GenerateTerrain();
            Destroy(this);
        }
    }
}
