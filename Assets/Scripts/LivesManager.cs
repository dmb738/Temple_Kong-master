using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour {

	private int lifeCounter;
	private Text livesText;

	// Use this for initialization
	void Start () {
		livesText = GetComponent<Text> ();
		lifeCounter = PlayerPrefs.GetInt("PlayerLives");
	}
	
	// Update is called once per frame
	void Update () {
		if (lifeCounter == 0) {
			SceneManager.LoadScene (0);
		}
		livesText.text = "Lives: " + lifeCounter;
	}
}
