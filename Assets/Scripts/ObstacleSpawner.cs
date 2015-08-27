using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObstacleSpawner : MonoBehaviour {

	public float minTime = 1;
	public float maxTime = 5;
	public Transform playerTransform;

	public Transform obstaclePrefab;
	public Transform pickupPrefab;

	// how far above the player obstacle should spawn
	private float yDistance = 15;

	private float lastObstacleSpawnTime;
	private float timeUntillObstacle;

	private float lastPickupSpawnTime;
	private float timeUntillPickup;


	void Start(){
		timeUntillObstacle = 0;
		lastObstacleSpawnTime = 0;
	}

	void Update () {
		SpawnObstacles ();

		SpawnPickups ();
	}

	void SpawnObstacles() {
		if (lastObstacleSpawnTime > timeUntillObstacle){
			timeUntillObstacle = Random.Range(minTime, maxTime);
			lastObstacleSpawnTime = 0;
			float xPosition = Random.Range(-7.5f, 7.5f);
			xPosition = (xPosition-1)*1.5f;
			Instantiate(obstaclePrefab, new Vector3(xPosition, playerTransform.position.y + yDistance, 0), Quaternion.identity) ;
		}
		lastObstacleSpawnTime += Time.deltaTime;
	}

	void SpawnPickups() {
		if (lastPickupSpawnTime > timeUntillPickup){
			timeUntillPickup = Random.Range(minTime, maxTime); // randomise time untill the next pickup
			lastPickupSpawnTime = 0;
			float xPosition = Random.Range(0, 5);
			xPosition = (xPosition-1)*1.5f;
			Instantiate(pickupPrefab, new Vector3(xPosition, playerTransform.position.y + yDistance, 0), Quaternion.identity) ;
		}
		lastPickupSpawnTime += Time.deltaTime;
	}


}