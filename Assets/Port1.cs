using UnityEngine;
using System.Collections;

public class Port1 : MonoBehaviour {
    public GameObject firstSpot;
    public GameObject backSpot;
    public Transform animal;

    private bool moved = false;
    private bool left;
    private bool right;
    
    void Update()
    {

    }
    public static float AngleDir(GameObject witch, Vector2 A, Vector2 B)// TO CHECK IF RIGHT OR LEFT this is for 2D 
    {
        return -A.x * B.y + A.y * B.x;//This returns a negative number if B is left of A, positive if right of A, or 0 if they are perfectly aligned.
    }

    private void LeftorRight()
    {
        if (left)
        {
            //you can teleport to the other place
        }
        else
        {
            //You cannot teleport teleport will be false?
        }
        if(right)
        {
            //you can teleport to the other
        }
        else
        {
            //you cannot teleport. Teleport false.
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Animal") && col.gameObject.CompareTag("Player")  )
        {

        }
    }
}
//public Transform target;
//private Vector2 mypos;

//void Start()/
//{
  //  mypos = transform.position;
    //var targetPos = target.position;
    //if (target.position.x < mypos.x && changed(mypos.y, targetPos.y))
    //{
      //  print("Right");
   // }
    //else if (changed(mypos.y, targetPos.y))
   // {
    //    print("Left");
    //}


    //Bare ha en hvor den går til et sted. Også en NY som går tilbake som kanskje er litt lengre back 

