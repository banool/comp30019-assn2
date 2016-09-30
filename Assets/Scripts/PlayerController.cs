using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float forwardSpeed = 0.25f;
    public float sideSpeed = 25.0f;
    public float friction = 5.0f;
    public float jump = 400.0f;
    public float sidewaysAirFrictionFactor = 2.0f;

    public ParticleSystem Particles;
    public int BurstNumber = 15;

    private Rigidbody rb;


    //GYRO STUFF
    public float gyroDeadzone = 5.0f;
    public float gyroMaxAngle = 30.0f;
    private Gyroscope m;
    private float gyroXInitialisationOffset;

    // Public with get so that the particle system knows if it is airborne.
    // If it is, it won't spawn additional particles when space is pressed.
    public bool onGround;


    // Use this for initialization
    void Start () {

        onGround = false;

        rb = GetComponent<Rigidbody>();

        //GYRO STUFF
        m = Input.gyro;
        m.enabled = true;
        gyroXInitialisationOffset = 360 - m.attitude.eulerAngles.x;

    }
	
	// Update is called once per frame
	void Update () {

        float moveHorizontal;
        DebugConsole.Log("Att: " + Input.gyro.attitude + ". Euler: " + Input.gyro.attitude.eulerAngles);

        Quaternion att = m.attitude;
        float xAngle = att.eulerAngles.x + gyroXInitialisationOffset;
        // Standarising to -180 to 180 degrees.
        if (xAngle > 180.0f) {
            xAngle -= 360.0f;
        }

        // Clamp the rotation (to about 30 degrees each side). Don't want to player 
        //  to have to rotate the device upside down for those super tight turns.
        if (Mathf.Abs(xAngle) > gyroMaxAngle) {
            xAngle = gyroMaxAngle * Mathf.Sign(xAngle);
        }
        DebugConsole.Log("xAngle: " + xAngle);

        // We keep a deadzone should be about 10 degrees.
        if (Mathf.Abs(xAngle) > gyroDeadzone) {
            moveHorizontal = -xAngle / gyroMaxAngle;
        } else {
            // If no gyro action, use the keyboard.
            moveHorizontal = Input.GetAxis("Horizontal");
        }

        // Assembling the final force vector (horizontal movement from arrow keys
        // or maybe forwards/backwards force based on power up.
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, forwardSpeed);

        // If in the air, quarter sideways movement ability.
        if (!onGround) {
            rb.AddForce(movement * sideSpeed/sidewaysAirFrictionFactor);
        } else {
            rb.AddForce(movement * sideSpeed);
        }

        // Apply sideways friction.
        int xMovementDirection;
        if (rb.velocity.x > 0) {
            xMovementDirection = 1;
        } else
        if (rb.velocity.x < 0) {
            xMovementDirection = -1;
        } else {
            xMovementDirection = 0;
        }

        Vector3 frictionVector = new Vector3(-xMovementDirection, 0.0f, 0.0f);
        rb.AddForce(friction * frictionVector);

        // Jump control
        if ((Input.GetKeyDown("space") || Input.touchCount > 0) && onGround) {
            rb.AddForce(0.0f, 1.0f * jump, 0.0f);
            onGround = false;
        }

    }

    // Onground for testing whether player can jump or not
    void OnCollisionEnter(Collision collision)
    {
        if (!onGround)
        {
            onGround = true;
            Particles.Emit(BurstNumber);
        }

    }

    public float getSpeed()
    {
        return rb.velocity.magnitude;
    }

}
