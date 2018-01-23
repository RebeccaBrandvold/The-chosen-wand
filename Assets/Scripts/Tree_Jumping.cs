using UnityEngine;
using System.Collections;

public class Tree_Jumping : MonoBehaviour
{
    //This script does so you can jump through the branches and land on top of them
    public Rigidbody2D PlayerRigB;

    private Collider2D col;

    private bool onPlatform = false;

    public LayerMask layermask;
    private Vector3 moveorgpos;
    public float movepos = 0.2f;

    void Start()
    {
        col = GetComponent<Collider2D>();
        //used to move the raycast further away from this object itself
        moveorgpos = new Vector3(0, movepos, 0);
    }

    void Update()
    {

        //If player is not on a platform, we can turn off collider so they can jump through branches
        if (!onPlatform)
        {
            col.enabled = false;
        }
        //If on platform, we want the player to not slide or move, so we freezepositionx. 
        if (onPlatform)
        {
            //As long as we are not moving, freeze
            if (!Input.GetKeyDown(KeyCode.A) || !Input.GetKeyDown(KeyCode.D))
            {
                //By having a "|" we can set multiple constraints without losing any constraints. Otherwise you do lose constraints.
                PlayerRigB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
        }
        //If the player wants down from a branch
        if (Input.GetKeyDown(KeyCode.S) && onPlatform)
        {
            col.enabled = false;
        }
        Debug.DrawRay(transform.position + moveorgpos, transform.up, Color.red);
        //Different raycasts: 
        //Physics2D.BoxCast(transform.position + moveorgpos, new Vector2(10, 2), 0, transform.up, 1f, layermask);
        RaycastHit2D hit = Physics2D.CircleCast(transform.position + moveorgpos, 1, transform.up, 0.1f, layermask);
        //RaycastHit2D hit = Physics2D.Raycast(transform.position + moveorgpos, transform.up, 0.2f, layermask);
        //Raycasting on the branch, it detects if an object is over it. 
        if (hit)
        {
            //If the player is falling down, for instance after jumping, we turn on the platform so they can stand
            if (PlayerRigB.velocity.y < -0.01f)
            {
                onPlatform = true;
                col.enabled = true;
            }
            //if the player is standing jumping, we turn off the platform
        }
        if (PlayerRigB.velocity.y > 0.01f)
        {
            onPlatform = false;
            col.enabled = false;
        }

    }
    //An extra needed check to see if we are still on the branch. If leaving, then turn it off. 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            onPlatform = false;
        }
    }

}