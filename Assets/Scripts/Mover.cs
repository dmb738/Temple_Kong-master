using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public Waypoint[] wayPoints;
	public float speed = 3f;
	public bool isCircular;
	// Always true at the beginning because the moving object will always move towards the first waypoint
	public bool inReverse = true;
    private Waypoint currentWaypoint;
	private int currentIndex   = 0;
	private bool isWaiting     = false;
	private float speedStorage = 0;
	private int randomInt	   = 0;
    private int score;

    //public BoxCollider2D Collider;

    /**
	 * Initialisation
	 * 
	 */
    void Start () {
        //Collider = GetComponent<BoxCollider2D>();
        if (wayPoints.Length > 0) {
			currentWaypoint = wayPoints[0];
		}
	}
	
	

	/**
	 * Update is called once per frame
	 * 
	 */
	void Update()
	{
        if (currentWaypoint != null && !isWaiting) {
			MoveTowardsWaypoint();
		}
		if (currentWaypoint == wayPoints[0] || currentWaypoint == wayPoints[1] || currentWaypoint == wayPoints[2] || currentWaypoint == wayPoints[3] || currentWaypoint == wayPoints[4] || currentWaypoint == wayPoints[5] || currentWaypoint == wayPoints[12] || currentWaypoint == wayPoints[13] || currentWaypoint == wayPoints[14] || currentWaypoint == wayPoints[15] || currentWaypoint == wayPoints[16] || currentWaypoint == wayPoints[17] || currentWaypoint == wayPoints[18] || currentWaypoint == wayPoints[19] || currentWaypoint == wayPoints[28] || currentWaypoint == wayPoints[29] || currentWaypoint == wayPoints[30] || currentWaypoint == wayPoints[31] || currentWaypoint == wayPoints[32] || currentWaypoint == wayPoints[33] || currentWaypoint == wayPoints[34]){
		RotateLeft();
		}else{
		RotateRight();
		}
    }



	/**
	 * Pause the mover
	 * 
	 */
	void Pause()
	{
		isWaiting = !isWaiting;
	}

    //private void OnTriggerEnter2D(Collider2D Collider)
    //{
    //    score = PlayerPrefs.GetInt("PlayerScore");
    //    score += 100;
    //    PlayerPrefs.SetInt("PlayerScore", score);
    //}
	
	/**
	 * Move the object towards the selected waypoint
	 * 
	 */
	private void MoveTowardsWaypoint()
	{
		// Get the moving objects current position
		Vector3 currentPosition = this.transform.position;
		
		// Get the target waypoints position
		Vector3 targetPosition = currentWaypoint.transform.position;
		
		// If the moving object isn't that close to the waypoint
		if(Vector3.Distance(currentPosition, targetPosition) > .01f) {

			// Get the direction and normalize
			Vector3 directionOfTravel = targetPosition - currentPosition;
			directionOfTravel.Normalize();
			
			//scale the movement on each axis by the directionOfTravel vector components
			this.transform.Translate(
				directionOfTravel.x * speed * Time.deltaTime,
				directionOfTravel.y * speed * Time.deltaTime,
				directionOfTravel.z * speed * Time.deltaTime,
				Space.World
			);
		} else {
			
			// If the waypoint has a pause amount then wait a bit
			if(currentWaypoint.waitSeconds > 0) {
				Pause();
				Invoke("Pause", currentWaypoint.waitSeconds);
			}

			// If the current waypoint has a speed change then change to it
			if(currentWaypoint.speedOut > 0) {
				speedStorage = speed;
				speed = currentWaypoint.speedOut;
			} else if(speedStorage != 0) {
				speed = speedStorage;
				speedStorage = 0;
			}
			randomInt = Random.Range(0,3);
			NextWaypoint();
		}
	}

	void RotateLeft() {
        //GetComponent<BoxCollider2D>().transform.Rotate(Vector3.forward * 10);
        transform.Rotate (Vector3.forward * -10);
	 }
	void RotateRight() {
        //GetComponent<BoxCollider2D>().transform.Rotate(Vector3.forward * -10);
        transform.Rotate (Vector3.forward * 10);
	 }


	/**
	 * Work out what the next waypoint is going to be
	 * 
	 */
	private void NextWaypoint()
	{
		if(isCircular) {
			
			if(!inReverse) {
				currentIndex = (currentIndex+1 >= wayPoints.Length) ? 0 : currentIndex+1;
			} else {
				currentIndex = (currentIndex == 0) ? wayPoints.Length-1 : currentIndex-1;
			}

		} else {
			
			// If at the start or the end then reverse
			if((!inReverse && currentIndex+1 >= wayPoints.Length) || (inReverse && currentIndex == 0)) {
				inReverse = !inReverse;
			}
			currentIndex = (!inReverse) ? currentIndex+1 : currentIndex-1;

		}
		
		if (currentWaypoint == wayPoints[1] && randomInt == 1) {
			currentWaypoint = wayPoints[7];
			currentIndex = 7;
		}else if (currentWaypoint == wayPoints[2] && randomInt == 1) {
			currentWaypoint = wayPoints[6];
			currentIndex = 6;
		}else if (currentWaypoint == wayPoints[8] && randomInt == 1) {
			currentWaypoint = wayPoints[15];
			currentIndex = 15;
		}else if (currentWaypoint == wayPoints[9] && randomInt == 1) {
			currentWaypoint = wayPoints[13];
			currentIndex = 13;
		}else if (currentWaypoint == wayPoints[14] && randomInt == 1) {
			currentWaypoint = wayPoints[24];
			currentIndex = 24;
		}else if (currentWaypoint == wayPoints[16] && randomInt == 1) {
			currentWaypoint = wayPoints[22];
			currentIndex = 22;
		}else if (currentWaypoint == wayPoints[17] && randomInt == 1) {
			currentWaypoint = wayPoints[21];
			currentIndex = 21;
		}else if (currentWaypoint == wayPoints[23] && randomInt == 1) {
			currentWaypoint = wayPoints[31];
			currentIndex = 31;
		}else if (currentWaypoint == wayPoints[25] && randomInt == 1) {
			currentWaypoint = wayPoints[29];
			currentIndex = 29;
		}else if (currentWaypoint == wayPoints[30] && randomInt == 1) {
			currentWaypoint = wayPoints[37];
			currentIndex = 37;
		}else if (currentWaypoint == wayPoints[32] && randomInt == 1) {
			currentWaypoint = wayPoints[36];
			currentIndex = 36;
		}
		else{
		
		currentWaypoint = wayPoints[currentIndex];
		}
       
        if (currentWaypoint.CompareTag("Despawn"))
        {
            Destroy(this.gameObject);
        }
        
    }
}