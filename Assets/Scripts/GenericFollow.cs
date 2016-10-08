using UnityEngine;
using System.Collections;

public class GenericFollow : MonoBehaviour {

    public PlayerController following;
    private Vector3 offset;

    // Use this for initialization
    void Start () {
        offset = transform.position - following.transform.position;
    }

    // Update is called once per frame
    void Update() {
        transform.position = following.transform.position + offset;
    }
}
