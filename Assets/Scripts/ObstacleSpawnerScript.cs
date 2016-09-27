using UnityEngine;
using System.Collections;

public class ObstacleSpawnerScript : MonoBehaviour {

    public int spawnX=0;
    public int offsetZ = 40;
    public int spawnX_range = 10;
    public int spawnFrequency=1;
    public PointLight light;
    public SlopeController slope;
    public PlayerController player;


    public GameObject obstacle;

    private float timer = 0;

    private Quaternion spawnRotation = Quaternion.Euler(0.0F,0.0F,0.0F);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            int newY = (int)(slope.transform.position.y+1);
            int newZ = (int)(player.transform.position.z)+offsetZ;

            spawnRotation = Quaternion.Euler(0.0F, Random.Range(0.0F, 360.0F), 0.0F);
            Vector3 spawnPos = new Vector3(spawnX+Random.Range(spawnX_range*-1,spawnX_range), newY, newZ);

            GameObject o = (GameObject) Instantiate(obstacle, spawnPos, spawnRotation);
            o.GetComponent<WallScript>().light = light;
            timer += spawnFrequency;
        }
	}
}
