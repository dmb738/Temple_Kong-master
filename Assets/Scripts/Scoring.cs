using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Scoring : MonoBehaviour {

    public GameObject player;
    public Text scoreText;
    public Text bonusText;
	private int score;
    private int bonus;

    // Use this for initialization
    void Start () {
        bonus = 5000;
		score = PlayerPrefs.GetInt ("PlayerScore");
        InvokeRepeating("SetBonusText", 0, 1.0f);
        SetScoreText();
    }
	
	// Update is called once per frame
	void Update () {
		score = PlayerPrefs.GetInt ("PlayerScore");
        SetScoreText();
    }

    void SetBonusText()
    {
        if (bonus > 0)
        {
            bonus -= 100;
            bonusText.text = "Bonus: " + bonus;
        }
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
