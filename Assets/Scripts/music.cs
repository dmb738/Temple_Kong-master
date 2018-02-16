using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour {
	public AudioClip musicClip;
	public AudioSource SoundSource;
	public float timeStamp;
	public float cooldown = 4f;

	// Use this for initialization
	void Start () {
		SoundSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (timeStamp <= Time.time) {
			timeStamp = Time.time + cooldown; 
			SoundSource.PlayOneShot (musicClip, 0.5f);
		}
	}
}
