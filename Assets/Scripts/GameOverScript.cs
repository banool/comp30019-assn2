using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

    private bool gameOver = false;
    private float gameOverTime;

    public void EndGame() {
        // Stop music playing.
        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();
        // Play explosion.
        GetComponent<AudioSource>().Play();
        // Display "Game Over" text.
        GetComponent<UnityEngine.UI.Text>().enabled = true;
        // Pause the game.
        Time.timeScale = 0;
        // This will trigger the game to actually end from the Update function.
        // Note that FixedUpdate stops when Time.timeScale = 0.
        gameOver = true;
        gameOverTime = Time.realtimeSinceStartup;
    }

    void Update() {
        // We make sure the game has been over for at least 1 second, so the
        // player doesn't accidentally click away from the game over screen.
        if (gameOver) {
            float timeSinceGameOver = Time.realtimeSinceStartup - gameOverTime;
            if (Input.anyKeyDown && (timeSinceGameOver > 1.0f)) {
                Time.timeScale = 1;
                SceneManager.LoadScene("WelcomeScreen");
            }
        }
    }
}
