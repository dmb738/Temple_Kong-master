using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour {

	public GameObject ghost;
	public float spawnTime;
	private float rando;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnTimeDelay ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnTimeDelay(){
		while (true) {
			rando = Random.value;
			if (rando >= .6) {
				Instantiate (ghost, transform.position, Quaternion.identity);
			}
			spawnTime = Random.Range (6.0f, 13.0f);
			yield return new WaitForSeconds (spawnTime);
		}
	}
}
