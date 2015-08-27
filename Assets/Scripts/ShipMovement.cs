using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {
	
	private Rigidbody2D rigidBody;
	public float speed = 15;

	private bool isRightDown;
	private bool isLeftDown;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();

	}

	// Update is called once per frame
	void Update () {

		HandleInput ();

		if (isRightDown && !isLeftDown) { // right only
			rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
		} else if (!isRightDown && isLeftDown) { // left only
			rigidBody.velocity = new Vector2(-speed, rigidBody.velocity.y);
		} else { // neither left nor right are down
			rigidBody.velocity = new Vector2(0f, rigidBody.velocity.y);
		}


	}

	void LateUpdate() {
		ConstrainToScreen ();
	}
	
	void ConstrainToScreen() {
		if (transform.position.x < -7.5f)
			transform.position = new Vector3(-7.5f, transform.position.y, transform.position.z);
		else if (transform.position.x > 7.5f)
			transform.position = new Vector3(7.5f, transform.position.y, transform.position.z);

	}

	void HandleInput() {
		if (Input.GetKeyDown (KeyCode.RightArrow))
			isRightDown = true;
		
		if (Input.GetKeyDown (KeyCode.LeftArrow))
			isLeftDown = true;
		
		if (Input.GetKeyUp (KeyCode.RightArrow))
			isRightDown = false;
		
		if (Input.GetKeyUp (KeyCode.LeftArrow))
			isLeftDown = false;
	}
}
