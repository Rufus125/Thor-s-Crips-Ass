using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Float : MonoBehaviour {

	public string label = "beerometer";
	private Rigidbody2D rigidBody;
	public float speed = 5;

	void Start() {
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		float beerValue = GameObject.Find (label).GetComponent<Slider>().value;

		rigidBody.velocity = new Vector2( rigidBody.velocity.x, -beerValue * speed);
	}
}
