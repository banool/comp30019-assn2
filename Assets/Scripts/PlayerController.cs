using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float forwardSpeed = 7.00f;
    public float sideSpeed = 80.0f;
    public float friction = 12.0f;
    public float jump = 400.0f;
    public float sidewaysAirFrictionFactor = 1.5f;
    public float accelerometerDeadzone = 0.05f;

    public ParticleSystem Particles;
    public int BurstNumber = 15;

    private Rigidbody rb;

    // Reduces the advantage that keyboard has over accelerometer.
    public float keyboardReductionFactor = 2.0f;

    // Public with get so that the particle system knows if it is airborne.
    // If it is, it won't spawn additional particles when space is pressed.
    public bool onGround;


    // Use this for initialization
    void Start () {
        onGround = false;
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        float moveHorizontal;
        // If there's accelerometer action, use that.
        if (Mathf.Abs(Input.acceleration.x) > accelerometerDeadzone) {
            moveHorizontal = Input.acceleration.x * sideSpeed; ;
        // Otherwise use the keyboard.
        } else {
            moveHorizontal = Input.GetAxis("Horizontal") * sideSpeed / keyboardReductionFactor;
        }

        // If in the air, reduce sideways movement ability.
        if (!onGround) {
            moveHorizontal /= sidewaysAirFrictionFactor;
        }

        // Assembling the final force vector (horizontal movement from arrow keys
        // or maybe forwards/backwards force based on power up.
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, forwardSpeed);
        rb.AddForce(movement);

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
        rb.AddForce(frictionVector * friction);

    }

    void Update() {
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
