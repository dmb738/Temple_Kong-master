using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour {
	public AudioClip pickupSound;
	public AudioSource SoundSource;
	public CircleCollider2D circleCollider;
	public BoxCollider2D boxCollider;
	private int score;

	void Start(){
		//SoundSource = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D(Collider2D collider){
		SoundSource.PlayOneShot (pickupSound, 0.5f);
		Destroy (gameObject);
		score = PlayerPrefs.GetInt ("PlayerScore");
		score += 800;
		PlayerPrefs.SetInt ("PlayerScore", score);
	}
}
