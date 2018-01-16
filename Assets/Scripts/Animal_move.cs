using UnityEngine;
using System.Collections;

public class Animal_move : MonoBehaviour
{

    public bool test;
    public bool wagging = false;
    public Animator anim;
    private SpriteRenderer rend;
    public float speed;
    private Rigidbody rb;
    public GameObject player;
    //public GameObject AnimalObj;
    public Transform Animal;
    public Transform Player;

    public float rayDistance = 2;
    private bool meetPlayer = false;
    private Player_movement playmove;
    private Crafting craft;

    // Use this for initialization
    void Start()
    {
        playmove = FindObjectOfType<Player_movement>();
        craft = FindObjectOfType<Crafting>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        StartCoroutine(wagnomore());
        //    //To get the colliders to ignore eachother. 


        //    //Makes the possebility to find the player
        rb = GetComponent<Rigidbody>();
        // player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(Player.GetComponent<Collider2D>(), Animal.GetComponent<Collider2D>());
        //Animation
        if (test)
        {
            wagging = true;
            anim.SetBool("Wagging", wagging);
        }
        else
        {
            wagging = false;
            anim.SetBool("Wagging", wagging);
        }

        //Makes the animal follow the player forever if they have sucessfully tamed. Unlocked = true when you have combined correctly in crafting script. 
        if (!meetPlayer && craft.unlocked)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //make the animal stop moving. 
            meetPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (playmove.playerturnedLeft)
            {
                rend.flipX = true;
            }
            else
                rend.flipX = false;
            meetPlayer = false;
        }
    }

    private IEnumerator wagnomore()
    {
        test = true;
        yield return new WaitForSeconds(3);
        //test = false;
    }
}

