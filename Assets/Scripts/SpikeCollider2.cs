using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollider2 : MonoBehaviour {
	public BoxCollider2D collider;
	public GameObject player;
	private int score;
	public AudioClip rockSound;
	public AudioSource SoundSource;
	public GameObject Despawn;
	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider2D> ();
		player = GameObject.Find("Player");
		Despawn = GameObject.Find("SpikeyDespawn");
		SoundSource = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		conveyor ();
		if (transform.position.x <= Despawn.transform.position.x && transform.position.y == Despawn.transform.position.y) {
				Destroy (gameObject);
			}
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
	public void conveyor(){
		if (Time.timeSinceLevelLoad <= 20) {
			transform.position += new Vector3 (-.01f, 0, 0);
			//print ("is working");
		}
		if (Time.timeSinceLevelLoad <= 40 && Time.timeSinceLevelLoad >= 20) {
			transform.position += new Vector3 (.01f, 0, 0);
			//print ("is working2");
		}
		if (Time.timeSinceLevelLoad <= 60 && Time.timeSinceLevelLoad >= 40) {
			transform.position += new Vector3 (-.01f, 0, 0);
			//print ("is working2");
		}
		if (Time.timeSinceLevelLoad >= 60) {
			transform.position += new Vector3 (.01f, 0, 0);
			//print ("is working2");
		}
	}
}
