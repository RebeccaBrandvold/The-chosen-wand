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

  

    void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();
       
    }


    void Update()
    {

        float rbvel = rb.velocity.magnitude;

        if (Input.GetKey(KeyCode.D))
        {
            movedRight = true;
            if (speed >= maxSpeed)
                speed = maxSpeed;
            else
                speed += acceleration;
        }
        else
        {
            if (speed <= minSpeed)
                speed = minSpeed;
            if (rbvel != 0)
                speed -= deacceleration;
            /*
			if (rbvel == 0) {
				speed = 0;
			}*/
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (movedRight)
            {
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
        else
        {
            if (speed <= minSpeed)
                speed = minSpeed;
            if (rbvel != 0)
                speed -= deacceleration;
        }


        Vector3 pos = new Vector3(speed * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0);
        transform.Translate(pos.x, pos.y, pos.z);

        if (Input.GetKeyDown(KeyCode.Space) && onGround == true || Input.GetKey(KeyCode.W) && onGround == true)
        {
            //transform.Translate (pos.x, jumpstrength * Time.deltaTime, pos.z);
            rb.velocity = new Vector2(rb.velocity.x, jumpstrength);
        }
        //transform.Translate (speed * Time.deltaTime * Input.GetAxis("Horizontal"), curheight, 0);
    }
   

}
