using UnityEngine;
using System.Collections;

public class BoundaryScript : MonoBehaviour {

	void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "obstacle") {
            Destroy(other.gameObject);
        }
    }
}
