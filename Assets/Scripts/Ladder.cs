using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {
	public BoxCollider2D collider;
	public GameObject player;
	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D collider){
        //print ("colliding");
		if (player.GetComponent<Player>().playerState != Player.PlatformerState.Hammer && player.GetComponent<Player>().playerState != Player.PlatformerState.Airborne) {
            if ((Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow))) {
                player.GetComponent<Player>().setStateClimbing();
            }
            if ((Input.GetKeyDown(KeyCode.S)) || (Input.GetKeyDown(KeyCode.DownArrow))) {
				player.GetComponent<Player> ().setStateClimbing ();
			}
		}
	}
	void OnTriggerExit2D(Collider2D collider){
		if(player.GetComponent<Player> ().playerState != Player.PlatformerState.Hammer){
		player.GetComponent<Player> ().playerState = Player.PlatformerState.Grounded;
		}
	}
}
