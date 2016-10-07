using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class DisplayScript : MonoBehaviour {


    public Text scoreText;
    public PlayerController player;
    static public  float score;

	// Use this for initialization
	void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {

        float playerSpeed = player.GetComponent<Rigidbody>().velocity.magnitude;
        score += playerSpeed * Time.deltaTime / 10;

        scoreText.text = "Score: " + ((int)((Mathf.Round(score * 100)) / 100)).ToString();
	}

    // Reduces score by set amount, going no lower than 0.
    public void reduceScore(float reduction) {
        score = Mathf.Max(0, score - reduction);
    }
}
