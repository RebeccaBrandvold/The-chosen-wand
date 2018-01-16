using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Stat health;
    public float decreasePerMinute;
    public bool death = false;
    public bool saved = false;
    public bool cameraTriggered;
    public bool witchHealing;
    //public Animation anim;
    public Animator anim;
    private void Awake() //
    {
        health.Initialized();
    }
    // Update is called once per frame
    void Update()
    {
        //Trying to get the health to decrease over time. 
        if(!saved && cameraTriggered)
        { 
        health.CurrentVal -= Time.deltaTime * decreasePerMinute / 60f;
             }
        // if (Input.GetKeyDown(KeyCode.Q))
        // {
        //   health.CurrentVal += 10; //reduces current value with 10
        // }
        if (Input.GetKeyDown(KeyCode.Space) && witchHealing && !death && !saved)
        {

            health.CurrentVal += 10; //reduces current value with 10
            //health.CurrentVal += 100; //reduces current value with 10
           // Debug.Log("bo" + health.CurrentVal);
        }
        if(health.CurrentVal >= 100)
        {
            saved = true;
        }
        if(health.CurrentVal <=0) 
        {   //Cue animtion
            //Cue sound
            anim = GetComponent<Animator>();
            death = true;
            anim.SetBool("NowYouDie", true);
            Debug.Log("Animation Playing");
            Debug.Log("Animation" + anim);
           
        }
        

    }

    //detect
    private void OnTriggerStay2D(Collider2D other)
    {
        //if (transform.parent && transform.parent.gameObject.name + "heal" + other.gameObject.name) ;

        if (other.gameObject.CompareTag("Player"))
        {
            witchHealing = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            witchHealing = false;
        }
    }



    //To start the death animation and maybe death sound. 
    //And stop the health from going up or down when pressed space
    private void dead()
    {   //If the current health is 0 then VVV
        if(health.CurrentVal <= 0)
        {   //if health.currentval = 0 then animalDeadAnimation = true. if animaldeadanimation = true then anim play.
          
            Debug.Log("animalDeadAnimation = True");     
            //Stop healing function
            
        }
        //To stop the health from going down and give the player the point
        //Maybe an animation for this too. Happy animal?
        if(health.CurrentVal >= 100)
        {

        }
    }
}
