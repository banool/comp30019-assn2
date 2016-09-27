using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScoreDisplayMenu : MonoBehaviour {

    public Text scoreText;

	
	void Start () {
        scoreText.text = "Score: " + ((Mathf.Round(DisplayScript.score * 100)) / 100).ToString();

    }
}
