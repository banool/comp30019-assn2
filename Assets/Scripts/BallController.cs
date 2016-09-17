using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

    public float spinSpeed;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    this.transform.localRotation *= Quaternion.AngleAxis(Time.deltaTime * spinSpeed, Vector3.up);
    }
}
