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

    private RaycastHit2D hit;
    private Healing heal;
    //public Bounds bounds;
    public Collider2D colPlayer;
    private LayerMask layermask;

    void Start()
    {
        heal = GetComponent<Healing>();
        rb = GetComponent<Rigidbody2D>();
        colPlayer = GetComponent<Collider2D>();
       //ayermask = GetComponent<LayerMask>();
        layermask = LayerMask.NameToLayer("Ground");
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
        //  public static RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance = Mathf.Infinity, int layerMask = DefaultRaycastLayers, float minDepth = -Mathf.Infinity, float maxDepth = Mathf.Infinity);
       //aycastHit2D ray;

        if (Physics2D.Raycast(transform.position, Vector3.down,2,layermask))
        {
            //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 2,layermask);
            Debug.DrawRay(transform.position, Vector3.down, Color.red);
           // Debug.Log("Hit ground");
            //transform.Translate(new Vector3(transform.position.x, colPlayer.bounds.extents.y, 0));

            // Vector3 posfixy = new Vector3(transform.position.x, hit.distance - colPlayer.bounds.extents.y, transform.position.z);
           // Vector3 posfixy = new Vector3(transform.position.x, hit.distance - transform.position.y, 0);
            //transform.Translate(posfixy.x, posfixy.y, posfixy.z);
          //float distanceToGround = hit.distance;
            //use below code if your pivot point is in the middle
          //float posPlayer = hit.distance - colPlayer.bounds.extents.z;
           //ransform.Translate(rb.position.x, posPlayer);s
            //use below code if your pivot point is at the bottom
            //transform.position.y = hit.distance;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
            onGround = true;
        if (other.gameObject.tag == "Companion")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (heal.curHealth == 3)
                {
                    heal.curHealth = 3;
                }
                else
                    heal.recoverHealth(1);
            }
        }
    }
}