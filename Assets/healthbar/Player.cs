using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    [SerializeField]
    private Stat health;


    private void Awake() //
    {
        health.Initialized();
    }
	// Update is called once per frame
	void Update () {
	
        if(Input.GetKeyDown(KeyCode.Q))
        {
            health.CurrentVal -= 10; //reduces current value with 10
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health.CurrentVal += 5; //reduces current value with 10
        }
    }
}
