using UnityEngine;
using System.Collections;

public class NormalAnimal : MonoBehaviour {
    [SerializeField]
    private Stat health;
    public float decreasePerMinute;
    public bool death = false;
    public bool saved = false;
    public bool cameraTriggered;
    public bool witchHealing;
    public Animator anim;
    private void Awake() //
    {
        health.Initialized();
    }
    // Update is called once per frame
    void Update()
    {
        //Trying to get the health to decrease over time. 
        if (!saved && cameraTriggered)
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
        if (health.CurrentVal >= 100)
        {
            saved = true;
        }
        if (health.CurrentVal <= 0)
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

}
