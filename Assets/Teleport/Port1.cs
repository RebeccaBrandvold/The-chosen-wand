using UnityEngine;
using System.Collections;

public class Port1 : MonoBehaviour
{
    public GameObject Exit;
    public GameObject Player;
    private float diff;

    public Transform animal;
    void Update()
    {
        //Playerpostion-thisposition = diff
        diff = Player.transform.position.x - this.transform.position.x;//Checking space between. 
        
        if(diff <= 0)
        {
            //høyre
        }
        else
        {
            //venstre
        }
    }
    private Vector2 move()
    {
        return animal.position = Exit.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D col)
    { 
            if(col.gameObject.CompareTag("Animal"))
            {
            move();
            }
        
    }

}
    