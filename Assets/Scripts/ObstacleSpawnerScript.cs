using UnityEngine;
using System.Collections;

public class ObstacleSpawnerScript : MonoBehaviour {

    public int spawnX=0;
    public int offsetZ = 40;
    public int spawnX_range = 10;
    public float spawnFrequency=10;

    public PointLight plight;
    public SlopeController slope;
    public PlayerController player;
    public GameObject obstacle;

    private float timer;
    private float yAboveSlope;
    private Quaternion spawnRotation;

	// Use this for initialization
	void Start () {
        yAboveSlope = slope.transform.position.y + 1;
        spawnRotation = Quaternion.Euler(0.0F, 0.0F, 0.0F);
        timer = 0;
    }
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime*player.getSpeed();
        if (timer < 0)
        {
            int newX = spawnX + Random.Range(spawnX_range * -1, spawnX_range);
            int newZ = (int)(player.transform.position.z) + offsetZ;
            spawnRotation = Quaternion.Euler(0.0F, Random.Range(0.0F, 360.0F), 0.0F);

            Vector3 spawnPos = new Vector3(newX, yAboveSlope, newZ);

            GameObject o = (GameObject) Instantiate(obstacle, spawnPos, spawnRotation);
            o.GetComponent<RockScript>().SetPLight(plight);
            timer += spawnFrequency;
        }
	}
}
