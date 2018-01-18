using UnityEngine;
using System.Collections;

public class rightTransform : MonoBehaviour {

    public GameObject Exit;
    public GameObject Player;
    public GameObject Entry1;
    public Transform animal;
    private float diff;
    private float spaceLeftShroom;
    private float spaceRightShroom; 
    public bool okayToTeleport = false;
	
	// Update is called once per frame
	void Update () {
        diff = Player.transform.position.x - this.transform.position.x;
        //
        spaceLeftShroom = Player.transform.position.x - Entry1.transform.position.x;
        spaceRightShroom = Player.transform.position.x - this.transform.position.x;
        //if player shroom  shroom player = kan se animal

        if (spaceRightShroom <= 0 && spaceLeftShroom >= 0 && okayToTeleport)//if player is to the left of right shroom and right of left shroom.
        {
            animal.gameObject.SetActive(false);//animal legone
        }
        //if shroom player shroom = kan ikke se animal
        //animal.gameObject.SetActive(true);
    }
    private void removeThyAnimal()
    {//If the witch is on the right side of the portal 
        if(diff <=0)
        {
            okayToTeleport = true;
          //  animal.gameObject.SetActive(false);
        }
        else
        {
         //   animal.gameObject.SetActive(true);
        }
    }
    private Vector2 teleport()
    {//Sends the animal to the position of the chosen exit. 
        return animal.position = Exit.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {//Checks if its okayToTeleport and if the col.gameobject is tagged animal
        if (okayToTeleport && col.gameObject.CompareTag("Animal"))
        {
            teleport();
        }
    }
}
