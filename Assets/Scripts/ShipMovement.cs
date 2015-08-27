using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {
	
	private Rigidbody2D rigidBody;
	public float speed = 15;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.RightArrow)){
				rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
			}
	if(Input.GetKeyDown(KeyCode.LeftArrow)){
		rigidBody.velocity = new Vector2(-speed, rigidBody.velocity.y);
		}
	}
}
