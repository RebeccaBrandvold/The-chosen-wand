using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Stat health;
    public float decreasePerMinute;
    public float HealingSum;
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

        //if (Input.GetKeyDown(KeyCode.Q))
        //{
            //health.CurrentVal -= 10; //reduces current value with 10
        //}
        if (Input.GetKeyDown(KeyCode.Space))
        {
           // health.CurrentVal += 10; //increases current value with number  DIS WORKS BUT  VVV THAT DOESNT????
            if (witchHealing)
            {
               
                health.CurrentVal += 10; //increases current value with number
                Debug.Log("currentValue" + health.CurrentVal);
                Debug.Log("MaxValue" + health.MaxVal);
            }
            
           
            //health.CurrentVal += 100; //+ current value with 10
            //Debug.Log("bo" + health.CurrentVal);
        }
    }

    //detect
    private void OnTriggerStay2D(Collider2D heal)
    {
        //if (transform.parent && transform.parent.gameObject.name + "heal" + other.gameObject.name) ;

        if (heal.gameObject.tag == "animal")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Pressed Space");
                health.CurrentVal += HealingSum;
                Debug.Log("CurrentValue" + health.CurrentVal);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                health.CurrentVal += 0;
            }
        }
       // else
        //{
          //  witchHealing = false;
       // }
    }

   // private void OnTriggerExit2D(Collider2D other)
    //{
     //   if(!other.gameObject.CompareTag("animal"))
       // {
         //   witchHealing = false;
        //}
    //}
}