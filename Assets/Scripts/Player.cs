using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour {
	//public LayerMask collisionMask;
	public AudioClip runSound;
	public AudioClip jumpSound;
	public AudioClip hammerSound;
	public AudioSource SoundSource;
	public float timeStamp;
	public float cooldown = .5f;
	//public float cooldown2 = 6.5f;

	public enum PlatformerState {Grounded, Airborne, Climbing, Dead, Hammer};
	public PlatformerState playerState;
	const float disableX = 0.0f;
	public float jumpHeight = 5f;
	public float timeToJumpApex = .4f;
	public float moveSpeed = 2f;
	//float accelerationTimeAirborne = .2f;
	//float accelerationTimeGrounded = .1f;
	private Animator animator;
	SpriteRenderer mario;

	//public GameObject Ladder;
	//BoxCollider2D collider;
	float gravity;
	float jumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;

	Controller2D controller;

	private int playerLives;

	// Use this for initialization
	void Start () {
		SoundSource = GetComponent<AudioSource> ();
		//collider = GetComponent<BoxCollider2D> ();
		animator = GetComponent<Animator>();
		controller = GetComponent<Controller2D> ();	
		mario = GetComponent<SpriteRenderer> ();
		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		print ("Gravity: " + gravity + " Jump Velocity: " + jumpVelocity);
	}

	void Update(){

		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}
		if (controller.collisions.below && playerState != PlatformerState.Climbing && playerState != PlatformerState.Dead && playerState != PlatformerState.Hammer) {
			playerState = PlatformerState.Grounded;
		}
		if (playerState == PlatformerState.Climbing) {
			gravity = 0f; 
			animator.SetTrigger ("playerClimbing");
		}
		if (playerState == PlatformerState.Dead) {
			playerLives = PlayerPrefs.GetInt ("PlayerLives");
			playerLives--;
			PlayerPrefs.SetInt ("PlayerLives", playerLives);
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}
	
		if (Input.GetKeyDown (KeyCode.Space) && controller.collisions.below && (Input.GetKey(KeyCode.D) == false) && (Input.GetKey(KeyCode.A) == false) && playerState != PlatformerState.Hammer) {
				playerState = PlatformerState.Airborne;
				velocity.y = jumpVelocity;
			SoundSource.PlayOneShot (jumpSound);
			}

		if (Input.GetKeyDown (KeyCode.Space) && controller.collisions.below && (Input.GetKey(KeyCode.D)) && playerState != PlatformerState.Hammer) {
			playerState = PlatformerState.Airborne;
			velocity.x = .5f;
			velocity.y = jumpVelocity;
			SoundSource.PlayOneShot (jumpSound);
		}
		if (Input.GetKeyDown (KeyCode.Space) && controller.collisions.below && (Input.GetKey(KeyCode.A)) && playerState != PlatformerState.Hammer) {
			playerState = PlatformerState.Airborne;
			velocity.x = -.5f;
			velocity.y = jumpVelocity;
			SoundSource.PlayOneShot (jumpSound);
		}
			
		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		velocity.y += gravity * Time.deltaTime;


		if (playerState == PlatformerState.Airborne) {
			//Vector2 input = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));
			controller.Move (velocity * Time.deltaTime);
			gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
			animator.SetTrigger ("playerJump");
		}
		if (playerState == PlatformerState.Grounded) {
			if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow)))
            {
				if (timeStamp <= Time.time) {
					timeStamp = Time.time + cooldown; 
					SoundSource.PlayOneShot (runSound, 0.5f);
				}
				mario.flipX = true;
				animator.SetTrigger ("playerRun");
			}
			if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow)))
            {
				if (timeStamp <= Time.time) {
					timeStamp = Time.time + cooldown; 
					SoundSource.PlayOneShot (runSound, 0.5f);
				}
				mario.flipX = false;
				animator.SetTrigger ("playerRun");
			}
			Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
			//float targetVelocityX = velocity.x = input.x * moveSpeed;
			velocity.x = input.x * moveSpeed; 
				//Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
			controller.Move (velocity * Time.deltaTime);

		
		}
		if (playerState == PlatformerState.Hammer) {
			animator.SetTrigger ("hammer");
			if (timeStamp <= Time.time) {
				timeStamp = Time.time + cooldown; 
				SoundSource.PlayOneShot (hammerSound, 0.5f);
			}
			if ((Input.GetKey (KeyCode.A)) || (Input.GetKey (KeyCode.LeftArrow))) {
				mario.flipX = true;
			}
			if ((Input.GetKey (KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow))) {
				mario.flipX = false;
			}
			Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
			//float targetVelocityX = velocity.x = input.x * moveSpeed;
			velocity.x = input.x * moveSpeed; 
			//Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
			controller.Move (velocity * Time.deltaTime);


		}
		if (((Input.GetKey (KeyCode.W)) || (Input.GetKey (KeyCode.UpArrow))) && (playerState == PlatformerState.Climbing)) {
			moveUp ();
		}
		if (((Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.DownArrow))) && (playerState == PlatformerState.Climbing)) {
			moveDown ();
		}
	}
	void moveUp(){
		transform.position += new Vector3 (0, .01f, 0);
	}
	void moveDown(){
		transform.position += new Vector3 (0, -.01f, 0);
	}
	public void setStateClimbing(){
		playerState = PlatformerState.Climbing;
	}
	public void conveyor(){
		if (Time.timeSinceLevelLoad <= 20 && playerState != PlatformerState.Climbing) {
			transform.position += new Vector3 (.01f, 0, 0);
			//print ("is working");
		}
		if (Time.timeSinceLevelLoad <= 40 && Time.timeSinceLevelLoad >= 20 && playerState != PlatformerState.Climbing) {
			transform.position += new Vector3 (-.01f, 0, 0);
			//print ("is working2");
		}
		if (Time.timeSinceLevelLoad <= 60 && Time.timeSinceLevelLoad >= 40 && playerState != PlatformerState.Climbing) {
			transform.position += new Vector3 (.01f, 0, 0);
			//print ("is working2");
		}
		if (Time.timeSinceLevelLoad >= 60 && playerState != PlatformerState.Climbing) {
			transform.position += new Vector3 (-.01f, 0, 0);
			//print ("is working2");
		}
	}
	public void conveyor2(){
		if (Time.timeSinceLevelLoad <= 20 && playerState != PlatformerState.Climbing) {
			transform.position += new Vector3 (-.01f, 0, 0);
			//print ("is working");
		}
		if (Time.timeSinceLevelLoad <= 40 && Time.timeSinceLevelLoad >= 20 && playerState != PlatformerState.Climbing) {
			transform.position += new Vector3 (.01f, 0, 0);
			//print ("is working2");
		}
		if (Time.timeSinceLevelLoad <= 60 && Time.timeSinceLevelLoad >= 40 && playerState != PlatformerState.Climbing) {
			transform.position += new Vector3 (-.01f, 0, 0);
			//print ("is working2");
		}
		if (Time.timeSinceLevelLoad >= 60 && playerState != PlatformerState.Climbing) {
			transform.position += new Vector3 (.01f, 0, 0);
			//print ("is working2");
		}
	}
}
