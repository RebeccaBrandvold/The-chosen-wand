using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player_movement : MonoBehaviour
{
    //The players rigidbody
    private Rigidbody2D rb;
    //Variables to control movement
    public float speed = 2;
    public float jumpstrength = 4;
    public float maxSpeed = 8;
    public float minSpeed = 0;
    public float acceleration = 0.1f;
    public float deacceleration = 0.01f;
    public bool onGround;
    //For turning the player the way it is going and making the animal look at the player. 
    private SpriteRenderer rend;
    public bool playerturnedLeft = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        //Get the normal vector to the velocity to the rigidbody. 
        float rbvel = rb.velocity.magnitude;

        //If you press D go to the right, turn sprite there
        if (Input.GetKey(KeyCode.D))
        {
            rend.flipX = true;
            //Used for the animal to know which direction it should turn itself after. Will follow player. 
            playerturnedLeft = true;
            //If you have hit maxspeed, then set the speed to max, so it won't go any further.
            //If not, then keep adding to speed, making it go faster
            if (speed >= maxSpeed)
                speed = maxSpeed;
            else
                speed += acceleration;
        }
        //Same as with D, except to the left
        if (Input.GetKey(KeyCode.A))
        {
            playerturnedLeft = false;
            rend.flipX = false;
            if (speed >= maxSpeed)
                speed = maxSpeed;
            else
                speed += acceleration;
        }

        //Used to move the player. Can be moved to if, but this way we only need to say it once.
        //moves according to the if, also with the acceleration.
        Vector3 pos = new Vector3(speed * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0);
        transform.Translate(pos.x, pos.y, pos.z);

        //When pressing space/w and you are on the ground, you can jump. Takes  hold of the rigidbodies velocity
        //and adds the jumpstrength to the y in velocity. 
        if (Input.GetKeyDown(KeyCode.Space) && onGround == true || Input.GetKey(KeyCode.W) && onGround == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpstrength);
        }
    }

    //If on anything jumpable, then onGround = true
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
            onGround = true;
        if (other.gameObject.tag == "Branch")
            onGround = true;
    }
    //Turn off that you can jump if you are not standing on the jumpables anymore. 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = false;
        }
        if (collision.gameObject.tag == "Branch")
        {
            onGround = false;
        }
    }
}