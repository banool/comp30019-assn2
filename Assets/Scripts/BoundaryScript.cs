using UnityEngine;
using System.Collections;

public class BoundaryScript : MonoBehaviour {

    public PlayerController player;
    private float offset;

	void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "obstacle") {
            Destroy(other.gameObject);
        }
    }

    void Start() {
        offset = transform.position.z - player.transform.position.z;
    }

    void Update() {
        transform.position = new Vector3(0.0f, 0.0f, (player.transform.position.z + offset));
    }
}
