using UnityEngine;
using System.Collections;

public class Tree_Jumping : MonoBehaviour
{
    //for some reason, it doesn't work when trying to ignore collision when one of the colliders are on an array
    //public Transform[] branches = new Transform[6];
   // public GameObject check;

    public Rigidbody2D PlayerRigB;
    public Transform PlayerTrans;
    public Transform branch1;
    public Transform branch2;
    public Transform branch3;
    public Transform branch4;
    public Transform branch5;
    public Transform branch6;

    // Use this for initialization
    void Start ()
    {
        //this.gameObject.layer = 0;
        //branches[6].gameObject.layer = 2;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Physics2D.IgnoreLayerCollision(8, 9, false);
        //Physics2D.IgnoreCollision(check2.GetComponent<Collider2D>(), PlayerTrans.GetComponent<Collider2D>());
        //Physics2D.IgnoreCollision(check2.GetComponent<Collider2D>(), PlayerTrans.GetComponent<Collider2D>());
        //When the player is jumping
       // if (PlayerRigB.velocity.y >= 0)
       // {
       //     Debug.Log("Jumping");
       //     Physics2D.IgnoreCollision(branch1.GetComponent<Collider2D>(), PlayerTrans.GetComponent<Collider2D>());
       //     Physics2D.IgnoreCollision(branch2.GetComponent<Collider2D>(), PlayerTrans.GetComponent<Collider2D>());
       //     Physics2D.IgnoreCollision(branch3.GetComponent<Collider2D>(), PlayerTrans.GetComponent<Collider2D>());
       //     Physics2D.IgnoreCollision(branch4.GetComponent<Collider2D>(), PlayerTrans.GetComponent<Collider2D>());
       //     Physics2D.IgnoreCollision(branch5.GetComponent<Collider2D>(), PlayerTrans.GetComponent<Collider2D>());
       //     Physics2D.IgnoreCollision(branch6.GetComponent<Collider2D>(), PlayerTrans.GetComponent<Collider2D>());
       // }
       // //When the player is falling down
       // else if(PlayerRigB.velocity.y < -0.5f)
       // {
       //     Debug.Log("Falling");
       //     Physics2D.IgnoreCollision(branch1.GetComponent<Collider2D>(), PlayerTrans.GetComponent<Collider2D>(), false);
       //     Physics2D.IgnoreCollision(branch2.GetComponent<Collider2D>(), PlayerTrans.GetComponent<Collider2D>(), false);
       //     Physics2D.IgnoreCollision(branch3.GetComponent<Collider2D>(), PlayerTrans.GetComponent<Collider2D>(), false);
       //     Physics2D.IgnoreCollision(branch4.GetComponent<Collider2D>(), PlayerTrans.GetComponent<Collider2D>(), false);
       //     Physics2D.IgnoreCollision(branch5.GetComponent<Collider2D>(), PlayerTrans.GetComponent<Collider2D>(), false);
       //     Physics2D.IgnoreCollision(branch6.GetComponent<Collider2D>(), PlayerTrans.GetComponent<Collider2D>(), false);
       // }
        //if(PlayerRigB.velocity.y > 2.0f)
        //{
        //    Physics2D.IgnoreCollision(branch1.GetComponent<Collider2D>(), PlayerTrans.GetComponent<Collider2D>(),true);
        //}
	}
    //if there is a triggerbox then we can say, okay, now you are inside, we remove the box so you can jump. 
    private void OnTriggerEnter2D(Collider2D collision)
    {
      //  if(collision.gameObject.CompareTag("Player"))
      //  {
      //      Debug.Log("In branch");
      //      Physics2D.IgnoreCollision(branch1.GetComponent<Collider2D>(), PlayerTrans.GetComponent<Collider2D>());
      //  }
    }
    //Check if the player is jumping. If it is, then we ignore collision between Player and these colliders.
}
