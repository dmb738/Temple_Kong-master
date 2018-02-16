using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conveyor : MonoBehaviour {
	public GameObject player;
	public Collider2D collider;
	//public float posX = player.transform.position.x;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		collider = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay2D(Collider2D collider){
		player.GetComponent<Player> ().conveyor ();
		//print ("colliding");
	}
}
