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
        //if player is to the left of right shroom and right of left shroom.
        if (spaceRightShroom <= 0 && spaceLeftShroom >= 0 && !okayToTeleport)
        { 
            animal.gameObject.SetActive(false);//animal legone
        }
        else
        {//Sets animal into the original 
            animal.gameObject.SetActive(true);
        }
        //if shroom-player-shroom = kan ikke se animal
        //animal.gameObject.SetActive(true);
    }

    //Need to remove the animal when the Witch is between the left and right bush.
    private void removeThyAnimal()
    {
        //If the witch is on the right side of the portal 
        if(diff <=0)
        {
            okayToTeleport = true;//okay to teleport.
            animal.gameObject.SetActive(false);
        }
        else//not okay to teleport when on the other side
        {
            animal.gameObject.SetActive(true);
        }
    }
    //The teleport function in itself. That changes the positon.
    private Vector2 teleport()
    {//Sends the animal to the position of the chosen exit. 
        return animal.position = Exit.transform.position;
    }
    //Need to check the collider if its okay to teleport and that the gameobject with the collider is tagged Animal
    private void OnTriggerEnter2D(Collider2D col)
    {//Checks if its okayToTeleport and if the col.gameobject is tagged animal
        if (okayToTeleport && col.gameObject.CompareTag("Animal"))
        {
            teleport();
        }
    }
}
