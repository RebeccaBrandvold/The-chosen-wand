using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Stat health;
    public float decreasePerMinute;

    public bool witchHealing ;

    private void Awake() //
    {
        health.Initialized();
    }
    // Update is called once per frame
    void Update()
    {
        //Trying to get the health to decrease over time. 
        health.CurrentVal -= Time.deltaTime * decreasePerMinute / 60f;

        // if (Input.GetKeyDown(KeyCode.Q))
        // {
        //   health.CurrentVal += 10; //reduces current value with 10
        // }
        if (Input.GetKeyDown(KeyCode.Space) && witchHealing)
        {

            health.CurrentVal += 10; //reduces current value with 10


            //health.CurrentVal += 100; //reduces current value with 10
            Debug.Log("bo" + health.CurrentVal);
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
     //  else
     //  {
     //      witchHealing = false;
     //  }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            witchHealing = false;
        }
    }
}