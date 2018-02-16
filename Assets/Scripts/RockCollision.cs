using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollision : MonoBehaviour {
	public CircleCollider2D collider;
	public GameObject player;
    private int score;
	public AudioClip rockSound;
	public AudioSource SoundSource;
    // Use this for initialization
	void Start () {
		collider = GetComponent<CircleCollider2D> ();
        player = GameObject.Find("Player");
		SoundSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D collider){
		SoundSource.PlayOneShot (rockSound);
		if (player.GetComponent<Player> ().playerState != Player.PlatformerState.Hammer) {
			player.GetComponent<Player> ().playerState = Player.PlatformerState.Dead;
		}
		if (player.GetComponent<Player> ().playerState == Player.PlatformerState.Hammer) {
			Destroy (gameObject);
			score = PlayerPrefs.GetInt ("PlayerScore");
			score += 500;
			PlayerPrefs.SetInt ("PlayerScore", score);
        }
	}
}
