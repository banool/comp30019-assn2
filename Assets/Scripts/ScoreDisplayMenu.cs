using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScoreDisplayMenu : MonoBehaviour {

    public Text scoreText;

	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + ((Mathf.Round(DisplayScript.score * 100)) / 100).ToString();

    }
}
