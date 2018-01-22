using UnityEngine;
using System.Collections;

public class leftTransform : MonoBehaviour {
    public GameObject Exit; //Where the portals exit is
    public GameObject Player; //Needs to know where the player is
    public GameObject RightBush; //Needs to know where the oposite portal entry is.
    public Transform animal; //Neeeds the transform of the animal to teleport the position.
    public GameObject animal1;
    private float playerLeftBushDiff;
    private float playerRightBushDiff;
    private float animalRightBushDiff;
    private float animalLeftBushDiff;
    public bool okayToTeleport = false; //Needs to check if its okay to teleport the animal.
    public bool isTeleported = false;//Need to check if animal has gone into teleporter.
    public bool witchBetweenBushes = false;

    void Update () {
       playerLeftBushDiff = Player.transform.position.x - this.transform.position.x;
       playerRightBushDiff = Player.transform.position.x - RightBush.transform.position.x;
       animalLeftBushDiff = animal1.transform.position.x - this.transform.position.x;
       animalRightBushDiff = animal1.transform.position.x - RightBush.transform.position.x;

        teleportTrue();
        removeThyAnimal();

        
	}
    
    //Checking if the withc is between the right and left bush
    //Sets the bool to true if she is
   public void WhereIsWitch()
    { //if(Witch-left >= 0 && witch-right <= 0)
        if(playerLeftBushDiff >=0 && playerRightBushDiff <=0)
        {
            witchBetweenBushes = true;
        }
        else
        {
            witchBetweenBushes = false;
        }
    }
   //Removes the animal when the witch is between the left and right bush
    private void removeThyAnimal()
    {
        //if player is to the left of right shroom and right of left shroom.
        if (witchBetweenBushes && isTeleported)
        {
            animal.gameObject.SetActive(false);//animal le-gone
        }
        else
        {//Sets animal into the original 
            animal.gameObject.SetActive(true);
        }
    }

//checks if the animal can teleport
private void teleportTrue()
 {//if(Player-left >=0)
    if(playerLeftBushDiff >=0 )
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
    {//Checks if its okaytoteleport and if the col.gameobject is tagged animal
        if (okayToTeleport && col.gameObject.CompareTag("Animal") /*|| animalLeftBushDiff >=0 && animalRightBushDiff <=0*/)
        {
            teleport();
          
        }
    }

    //The teleport function in itself. That changes the positon.
    private Vector2 teleport()
    {
        isTeleported = true;//Checks if animal has teleported. 
        //Checks if animal has teleported. should be here or in teleport()     
        return animal.position = Exit.transform.position;   
    }
}
//Needs two Trigger Colliders to work because if the withc walks too slow the animal wont teleport
//IM MISSING THE PART WHERE IT'LL STOP SPAMMING TELEPORT BACK AND FORTH.