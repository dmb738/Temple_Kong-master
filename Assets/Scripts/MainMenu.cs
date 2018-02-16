using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public Texture background;
	public int playerLives = 3;
	public int playerScore = 0;

	void Start() {
		PlayerPrefs.SetInt ("PlayerLives", playerLives);
		PlayerPrefs.SetInt ("PlayerScore", playerScore);
	}

    void OnGUI()
    {
        float width = 512;
        float height = 512;
        GUI.DrawTexture(new Rect((Screen.width / 2) - (width / 2), (Screen.height / 2) - (height / 2), width, height), background);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            // If Standalone:
            // Application.Quit();
            // If WebGL:
            Application.OpenURL("about:blank");
            // If Unity Editor:
            // UnityEditor.EditorApplication.isPlaying = false;
        }
        else if (Input.anyKeyDown)
        {
			SceneManager.LoadScene (1);
        }
    }
}
