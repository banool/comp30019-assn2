using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class DisplayScript : MonoBehaviour {


    public Text scoreText;
    static public  float score;

	// Use this for initialization
	void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {

        score = score + Time.deltaTime;

        scoreText.text = "Score: " + ((Mathf.Round(score * 100)) / 100).ToString("F2");
	}
}
