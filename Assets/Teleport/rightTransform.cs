using UnityEngine;
using System.Collections;

public class rightTransform : MonoBehaviour {

    public GameObject Exit; //Where the portals exit is
    public GameObject Player; //Needs to know where the player is
    public GameObject leftBush; //Needs to know where the oposite portal entry is.
    public Transform animal; //Neeeds the transform of the animal to teleport the position.
    public GameObject animal1;
    private float playerRightBushDiff;
    private float playerLeftBushDiff;
    private float animalRightBushDiff;
    private float animalLeftBushDiff;
    public bool okayToTeleport = false; //Needs to check if its okay to teleport the animal.
    public bool isTeleported = false;//Need to check if animal has gone into teleporter.
    public bool witchBetweenBushes = false;
	
	// Update is called once per frame
	void Update () {
        playerRightBushDiff = Player.transform.position.x - this.transform.position.x;
        playerLeftBushDiff = Player.transform.position.x - leftBush.transform.position.x;
        animalRightBushDiff = animal1.transform.position.x - this.transform.position.x;
        animalLeftBushDiff = animal1.transform.position.x - leftBush.transform.position.x;

        teleportTrue();
        removeThyAnimal();
    }

  //Checking if the Witch is between the Right and Left bush.
  //Sets the bool to true if she is. 
  public void WhereIsWitch()
    {//if(Witch-right <=0 && Witch-left >=0)
        if(playerRightBushDiff <=0 && playerLeftBushDiff >=0)
        {
            witchBetweenBushes = true;
        }
        else
        {
            witchBetweenBushes = false;
        }
    }
   
    //Need to remove the animal when the Witch is between the left and right bush.
    private void removeThyAnimal()
    {
        //If its true, then the animal should be gone. Until the function is false again. 
        if (witchBetweenBushes && isTeleported)
        {
            animal.gameObject.SetActive(false);//animal le-gone
        }
        else
        {//Sets animal into the original 
            animal.gameObject.SetActive(true);
        }
    }

   //Checks if the animal can teleport
    private void teleportTrue()
    {//if(player-right <= 0)
        if (playerRightBushDiff <= 0)
        {
            okayToTeleport = true;
            removeThyAnimal();
        }
        else
        {
            okayToTeleport = false;
        }      
    }

    //Need to check the collider if its okay to teleport and that the gameobject with the collider is tagged Animal
    private void OnTriggerEnter2D(Collider2D col)
    {//Checks if its okayToTeleport and if the col.gameobject is tagged animal
        if (okayToTeleport && col.gameObject.CompareTag("Animal")/* || animalRightBushDiff <=0 && animalLeftBushDiff >= 0*/)
        {
            teleport();          
        }
    }

    //The teleport function in itself. That changes the positon.
    private Vector2 teleport()
    {
        isTeleported = true;//Checks if animal has teleported.
        //Sends the animal to the position of the chosen exit. 
        return animal.position = Exit.transform.position;
    }
}
//Needs two Trigger Colliders to work because if the withc walks too slow the animal wont teleport
//IM MISSING THE PART WHERE IT'LL STOP SPAMMING TELEPORT BACK AND FORTH.