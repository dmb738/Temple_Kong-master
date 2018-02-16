using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZones : MonoBehaviour {
	public Collider2D collider;
	public GameObject player;
	// Use this for initialization
	void Start () {
		collider = GetComponent<Collider2D> ();
	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D(Collider2D collider){
		player.GetComponent<Player> ().playerState = Player.PlatformerState.Dead;
	}
}
