using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WelcomeControl : MonoBehaviour {

    public void PlayFunction() {
        SceneManager.LoadScene("MainGame");
    }

    public void HowToPlayFunction() {

    }

    public void CustomiseFunction() {

    }

    public void SettingsFunction() {

    }

	public void ExitFunction() {
        Application.Quit();
    }
}
