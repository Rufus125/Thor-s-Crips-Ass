using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class moveIcebergs : MonoBehaviour {

	public string label = "beerometer";
	public float speed = 5;
	
	// Update is called once per frame
	void Update () {
		float beerValue = GameObject.Find (label).GetComponent<Slider>().value;

		transform.position = new Vector2(transform.position.x,
		                                 transform.position.y - beerValue * speed);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		print ("collision");
	}
}
