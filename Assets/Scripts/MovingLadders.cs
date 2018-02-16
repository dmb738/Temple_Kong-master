using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLadders : MonoBehaviour {
	public bool pos = true;
	public float timeStamp;
	public float cooldown = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timeStamp <= Time.time) {
			if (pos == true) {
				
				transform.position += new Vector3 (0, -.01f, 0);
			}
			if (pos == false) {
				
				transform.position += new Vector3 (0, .01f, 0);
			}
			if (transform.position.y <= -2.239f) {
				timeStamp += Time.time + cooldown;

				pos = !pos;
			}
			if (transform.position.y >= -2.015f) {
				timeStamp += Time.time + cooldown;

				pos = !pos;
			}
		}
	}
}
