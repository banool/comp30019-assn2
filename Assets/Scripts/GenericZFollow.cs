using UnityEngine;
using System.Collections;

public class GenericZFollow : MonoBehaviour
{

    public PlayerController following;
    private float offset;
    private float startX;
    private float startY;

    // Use this for initialization
    void Start() {
        offset = transform.position.z - following.transform.position.z;
        startX = transform.position.x;
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(startX, startY, following.transform.position.z + offset);
    }
}
