using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player_movement : MonoBehaviour 
{
	private Rigidbody2D rb;
	public float speed = 2;
	public float jumpstrength = 4;
	public float maxSpeed = 8;
	public float minSpeed = 0;
	public float acceleration = 0.1f;
	public float deacceleration = 0.01f;
	public bool movedRight = false;
	public bool onGround;
	public Text oldWord;
	public bool hitWord = false;
	public bool FirstWord = true;
	public bool hasWord = true;
	public GameObject Swim;
	public GameObject Fuck;
	public Text newWord;
	private WordManagment word;
	public Text stored;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		//stored = GetComponent<GameObject> ();
		word = GetComponent<WordManagment> ();
		//curword = Fuck.GetComponent<Text> ();
	}


	void Update () {

		float rbvel = rb.velocity.magnitude;

		if (Input.GetKey (KeyCode.D)){
			movedRight = true;
			if (speed >= maxSpeed)
				speed = maxSpeed;
			else
				speed += acceleration;
		}
		else{
			if (speed <= minSpeed)
				speed = minSpeed;
			if (rbvel != 0)
				speed -= deacceleration;
			/*
			if (rbvel == 0) {
				speed = 0;
			}*/
		}

		if (Input.GetKey (KeyCode.A)) {
			if (movedRight) {
				speed = speed / 2;
				movedRight = false;
			}
			//this works, but it's kinda annoying that the character loses speed when turning the other direction, even though it would make sense.
			//Also, I haven't done it the other way yet. 
			if (speed >= maxSpeed)
				speed = maxSpeed;
			else
				speed += acceleration;
		} 
		else {
			if (speed <= minSpeed)
				speed = minSpeed;
			if (rbvel != 0)
				speed -= deacceleration;
		}
			

		Vector3 pos = new Vector3 (speed * Time.deltaTime * Input.GetAxis ("Horizontal"), 0, 0);
		transform.Translate(pos.x, pos.y, pos.z);

		if (Input.GetKeyDown (KeyCode.Space) && onGround == true|| Input.GetKey(KeyCode.W) && onGround == true){
			//transform.Translate (pos.x, jumpstrength * Time.deltaTime, pos.z);
			rb.velocity = new Vector2(rb.velocity.x, jumpstrength);
		}
		//transform.Translate (speed * Time.deltaTime * Input.GetAxis("Horizontal"), curheight, 0);
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Ground")
			onGround = true;
	}
	/*
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.name == "Ground")
			onGround = false;
	}*/


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Word") {
			//have to find the text that is connected to that GameObject
			//on this gameobject we want to find the connected Text
			newWord = other.gameObject.GetComponent<Text> ();
			//stored = other.gameObject.GetComponent<Text> ();
			//starts the replacment
			hasWord = true;
			//then the oldword gets the same text. This to store the length of the word
			oldWord = other.gameObject.GetComponent<Text> ();
			//other.gameObject.SetActive (false);
			hitWord = true;
			FirstWord = false;
		} else {
			hasWord = false;
			hitWord = false;
		}
		//need to activate the previous gameObject if we find another one
		//need to replace the new word with the old
	}

}
