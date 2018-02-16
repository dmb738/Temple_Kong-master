using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour {
	public BoxCollider2D collider;
	public GameObject player;
	public float timeStamp;
	public float cooldown = 3.75f;
	public int count = 0;
	//public bool hammerState = false;
	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider2D> ();
	}

	// Update is called once per frame
	void Update () {
		//if ((Input.GetKey (KeyCode.A)) || (Input.GetKey (KeyCode.LeftArrow)) || (Input.GetKey (KeyCode.D)) || (Input.GetKey (KeyCode.RightArrow))) {
			if (timeStamp <= Time.time && player.GetComponent<Player> ().playerState == Player.PlatformerState.Hammer) {
				timeStamp = Time.time + cooldown;
				//hammerState = !hammerState;
				count = count + 1;
				/*if (player.GetComponent<Player> ().playerState == Player.PlatformerState.Hammer && count == 3) {
					player.GetComponent<Player> ().playerState = Player.PlatformerState.Grounded;
				}*/
			}
		//}
		if (player.GetComponent<Player> ().playerState == Player.PlatformerState.Hammer && count == 2) {
			player.GetComponent<Player> ().playerState = Player.PlatformerState.Grounded;
			count = 0;
		}
	}
	void OnTriggerEnter2D(Collider2D collider){
		//timeStamp = Time.time + cooldown; 
		//hammerState = false;
		count = 0;
        player.GetComponent<Player> ().playerState = Player.PlatformerState.Hammer;
		Destroy (gameObject);
    }
}
