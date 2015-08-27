using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	public float speed = 15;
	public Slider beerometer;
	public Color beercolor;
	private Rigidbody2D rigidBody;
	private bool isRightDown;
	private bool isLeftDown;
	[SerializeField]
	private float
		minBeerValue = 0.05f;
	[SerializeField]
	private float
		dangerZone = 0.9f;
	[SerializeField]
	private float
		happyZone = 0.6f;
	private Image SliderImage;
	//drunken moves are done every second time
	private int i = 0;
	//change the face image on the top right
	private Image face;
	private Sprite drunkenSprite;
	private Sprite normalSprite;
	private Sprite happySprite;

	// Use this for initialization
	void Start ()
	{
		Texture2D txt2D = Resources.Load ("Images/face_drunk") as Texture2D;
		drunkenSprite = Sprite.Create (txt2D as Texture2D, new Rect (0f, 0f, txt2D.width, txt2D.height), Vector2.zero);

		txt2D = Resources.Load ("Images/face_normal") as Texture2D;
		normalSprite = Sprite.Create (txt2D as Texture2D, new Rect (0f, 0f, txt2D.width, txt2D.height), Vector2.zero);

		txt2D = Resources.Load ("Images/face_happy") as Texture2D;
		happySprite = Sprite.Create (txt2D as Texture2D, new Rect (0f, 0f, txt2D.width, txt2D.height), Vector2.zero);
		
		face = GameObject.Find ("ThorsFace").GetComponent<Image> ();
		rigidBody = GetComponent<Rigidbody2D> ();
		beerometer.value = 0.5f;

		SliderImage = beerometer.GetComponentsInChildren<UnityEngine.UI.Image> () [1];
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		HandleInput ();
		Move ();

		if (Input.GetKeyDown (KeyCode.C)) {
			beerometer.value += 0.1f;
		} else {
			beerometer.value -= Time.deltaTime * 0.3f;

			if (beerometer.value < minBeerValue) {
				beerometer.value = minBeerValue;
			} else if (beerometer.value > dangerZone) {
				SliderImage.color = Color.Lerp (SliderImage.color, Color.red, 0.1f);

				face.sprite = drunkenSprite;
				if (i++ % 2 == 0) {
					float DrunkenSpeed = Random.Range (-22, 22);
					rigidBody.velocity = new Vector2 (DrunkenSpeed, rigidBody.velocity.y);
				}
			} else if (SliderImage.color != beercolor) {
				SliderImage.color = Color.Lerp (SliderImage.color, beercolor, 0.2f);
				if (beerometer.value > happyZone) {
					face.sprite = happySprite;
				}
			} else {

				face.sprite = normalSprite;
			}
			
		}
	}
	
	void LateUpdate ()
	{
		ConstrainToScreen ();
	}
	
	void ConstrainToScreen ()
	{
		if (transform.position.x < -7.5f)
			transform.position = new Vector3 (-7.5f, transform.position.y, transform.position.z);
		else if (transform.position.x > 7.5f)
			transform.position = new Vector3 (7.5f, transform.position.y, transform.position.z);
		
	}
	
	void HandleInput ()
	{
		if (Input.GetKeyDown (KeyCode.RightArrow))
			isRightDown = true;
		
		if (Input.GetKeyDown (KeyCode.LeftArrow))
			isLeftDown = true;
		
		if (Input.GetKeyUp (KeyCode.RightArrow))
			isRightDown = false;
		
		if (Input.GetKeyUp (KeyCode.LeftArrow))
			isLeftDown = false;
	}

	void Move ()
	{		
		if (isRightDown && !isLeftDown) { // right only
			rigidBody.velocity = new Vector2 (speed, rigidBody.velocity.y);
		} else if (!isRightDown && isLeftDown) { // left only
			rigidBody.velocity = new Vector2 (-speed, rigidBody.velocity.y);
		} else { // neither left nor right are down
			rigidBody.velocity = new Vector2 (0f, rigidBody.velocity.y);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Beer"))
		{
			Destroy(collision.gameObject);
			Debug.Log("You wonasdfasdf !!!");
		} else if (collision.gameObject.CompareTag("Iceberg"))
		{
			Destroy(collision.gameObject);
			Debug.Log("You FAIL !!!");
		}
	}
}
