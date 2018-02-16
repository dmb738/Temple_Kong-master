using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float moveSpeed;
	public enum PlatformerState {Grounded, Airborne, Climbing, Dead};
	public PlatformerState playerState;

	// Use this for initialization
	void Start () {

	}


	// Update is called once per frame
	void Update () {
		if(Input.GetKey("w")&&playerState == PlatformerState.Climbing)
		{
			moveUp ();
		}
		if(Input.GetKey("s"))
		{
			moveDown ();
		}
		if(Input.GetKey("a"))
		{
			moveLeft ();
		}
		if(Input.GetKey("d"))
		{
			moveRight ();
		}

	}

	void moveUp()
	{
		transform.position += new Vector3 (0, moveSpeed, 0);
	}
	void moveDown()
	{
		transform.position -= new Vector3 (0, moveSpeed, 0);
	}
	void moveLeft()
	{
		transform.position -= new Vector3 (moveSpeed, 0, 0);
	}
	void moveRight()
	{
		transform.position += new Vector3 (moveSpeed, 0, 0);
	}
}