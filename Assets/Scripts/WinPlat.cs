using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPlat : MonoBehaviour {
	public Collider2D collider;
	// Use this for initialization
	void Start () {
		collider = GetComponent<Collider2D> ();
	}
	void OnTriggerEnter2D(Collider2D collider){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}
}
