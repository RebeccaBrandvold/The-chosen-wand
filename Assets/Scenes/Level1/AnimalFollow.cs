using UnityEngine;
using System.Collections;

public class AnimalFollow : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    private GameObject player;
    public Transform Animal;
    public Transform Player;
    void Start()
    {
        //To get the colliders to ignore eachother. 
        Physics.IgnoreCollision(Player.GetComponent<Collider>(), Animal.GetComponent<Collider>());
    //Makes the possebility to find the player
    rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

    }

    void FixedUpdate()
    {//Makes the animal follow the player forever.
        transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
       
    }

    
}
