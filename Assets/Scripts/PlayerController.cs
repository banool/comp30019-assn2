using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {



    //Player controller
    //Handles shader stuff
    // Tried and failed to implemenet gyro stuff
    // at the moment, arrow keys move left/right, space to jump
    public float forwardSpeed = 0.25f;
    public float sideSpeed = 25.0f;
    public float friction = 5.0f;
    public float jump = 400.0f;
    public float sidewaysAirFrictionFactor = 2.0f;
    public Shader shader;

    public PointLight plight;



    private Rigidbody rb;


    //GYRO STUFF

    private Gyroscope m;

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



        //shading stuff

        MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();
        renderer.material.shader = shader;

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Color[] colors = new Color[vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
            colors[i] = new Color(0.5F, 0.5F, 0.5F, 1.0F);

        mesh.colors = colors;


    }
	
	// Update is called once per frame
	void Update () {

        float moveHorizontal = Input.GetAxis("Horizontal");

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
        if (rb.velocity.x > 0)
            xMovementDirection = 1;
        else
            xMovementDirection = -1;

        Vector3 frictionVector = new Vector3(-xMovementDirection, 0.0f, 0.0f);
        rb.AddForce(friction * frictionVector);



        //GYRO STUFF

        //attempt 1

        //transform.Translate(Input.acceleration.x*100, 0, -Input.acceleration.z*100);


        //attempt 2

        // Vector3 dir = Vector3.zero;
        // dir.x = -Input.acceleration.x;
        // dir.y = Input.acceleration.y;
        //  if (dir.sqrMagnitude > 1)
        //      dir.Normalize();
        //  dir *= Time.deltaTime;
        //  transform.Translate(dir * speed);

        //debug
        //print((Input.acceleration.x).ToString()+","+ (Input.acceleration.y.ToString()) + "," + (Input.acceleration.z).ToString());
        //print((m.enabled).ToString() + "," + (m.userAcceleration).ToString() + "," + (m.rotationRate).ToString());
        //print(SystemInfo.supportsAccelerometer);


        //shading stuff
        MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();

        renderer.material.SetColor("_PointLightColor", this.plight.color);
        renderer.material.SetVector("_PointLightPosition", this.plight.GetWorldPosition());


        //Jump control
        if (Input.GetKeyDown("space") && onGround) {
            rb.AddForce(0.0f, 1.0f * jump, 0.0f);
            onGround = false;
        }

    }

    //Onground for tesdtig whether player can jump or not
    void OnCollisionEnter(Collision collision)
    {
        onGround = true;

    }

}
