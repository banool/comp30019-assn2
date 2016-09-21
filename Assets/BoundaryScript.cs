using UnityEngine;
using System.Collections;

public class BoundaryScript : MonoBehaviour {

	void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);

    }
}
