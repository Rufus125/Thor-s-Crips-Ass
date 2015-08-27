using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObstacleSpawner : MonoBehaviour {

	public GameObject beer;
	public GameObject icebrerg;
	public Slider slider;

	// Use this for initialization
	void Start () {
		slider.value = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
