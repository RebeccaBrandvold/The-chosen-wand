using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inventory : MonoBehaviour
{
    //An array which holds the items you can pick up. Items in the inventory
    public GameObject[] items = new GameObject[6];
    //used to check if the image are supposed to change from silhoutte to an image with fully color. Happens when you pick it up
    private bool changesprite = false;
    private bool changesprite1 = false;
    private bool changesprite2 = false;
    private bool changesprite3 = false;
    private bool changesprite4 = false;
    private bool changesprite5 = false;
    //These are the saved images and sprites to the different items
    public Image image;
    public Sprite sprite;

    public Image image1;
    public Sprite sprite1;

    public Image image2;
    public Sprite sprite2;

    public Image image3;
    public Sprite sprite3;

    public Image image4;
    public Sprite sprite4;

    public Image image5;
    public Sprite sprite5;

    //the items in the scene
    public GameObject rogn;
    public GameObject kantarell;
    public GameObject salmon;
    public GameObject Rose_red;
    public GameObject rose_yellow;
    public GameObject stone;


    void Start ()
    {
        kantarell.GetComponent<Drag>().enabled = false;
        rogn.GetComponent<Drag>().enabled = false;
        salmon.GetComponent<Drag>().enabled = false;
    }
	
	// Update is called once per frame

	void Update ()
    {
        //We change the image on the object
        if(changesprite)
            image.sprite = sprite;
        if (changesprite1)
            image1.sprite = sprite1;
        if (changesprite2)
            image2.sprite = sprite2;

        if (changesprite3)
            image3.sprite = sprite3;
        if (changesprite4)
            image4.sprite = sprite4;
        if (changesprite5)
            image5.sprite = sprite5;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.CompareTag("Items"))
        //{
        //    item = collision.gameObject;
        //
        //
        //}
        //A way to see the silhoutte in inventory. 
        if (collision.gameObject.CompareTag("Rogn"))
        {
            //turns on the script drag, so they become dragable
            rogn.GetComponent<Drag>().enabled = true;
            //We have set which item is where in the array, so we know that Rogn is in place 1, and disactivate the silhoutte and the image itself. 
            items[1].SetActive(false);
            //This will lead us into an if that changes the image.
            changesprite1 = true;
        }
        if (collision.gameObject.CompareTag("Kantarell"))
        {
            kantarell.GetComponent<Drag>().enabled = true;
            items[0].SetActive(false);
            changesprite = true;
        }

        if (collision.gameObject.CompareTag("Salmon"))
        {
            salmon.GetComponent<Drag>().enabled = true;
            items[2].SetActive(false);
            changesprite2 = true;
        }
        if (collision.gameObject.CompareTag("Rose_red"))
        {
            Rose_red.GetComponent<Drag>().enabled = true;
            items[3].SetActive(false);
            changesprite3 = true;
        }
        if (collision.gameObject.CompareTag("Rose_yellow"))
        {
            rose_yellow.GetComponent<Drag>().enabled = true;
            items[4].SetActive(false);
            changesprite4 = true;
        }
        if (collision.gameObject.CompareTag("Stone"))
        {
            stone.GetComponent<Drag>().enabled = true;
            items[5].SetActive(false);
            changesprite5 = true;
        }

    }
}





















//An attempt to have an inventory system where when you pick up something it gathers the info from the object is crashed into and then get that sprite and put it into an empty slot. 

//invSprite[0] = spriteInv;
//get the sprite from our current object
//invmushroom = mushroom;
//spriteItem = collision.gameObject.GetComponent<Sprite>();
// spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
//get our sprite from our current position in inventory
//spriteInv = invSprite[count].GetComponent<Sprite>();
//spriteInv = spriteItem;
//set that sprite from inventory to the sprite from the gameobject
//spriteInv = spriteRenderer;
// invSprite[count] = sprite;
//count++;
//could simply setactive true and false accordingly to now you got a tantarell = activte. But the placement of the inventory might be weird cuz then they have a certain place in inventory. Maybe it doesn't matter??

//public GameObject[] sprite = new GameObject[7];//array som lagrer kid counter bildene
//private int coincount;
//void Start()
//{
//    coincount = 0;
//    sprite[coincount].SetActive(true);//aktiverer bildene så de kan brukes
//
//}
//
//void Update()
//{
//
//}
//void OnTriggerEnter2D(Collider2D CollectCoins) //hele denne passer på at når man er i en collider med tag "Coin" så starter tellingen. 
//{
//    if (CollectCoins.gameObject.CompareTag("Coin")) //leter etter tagen Coin
//    {
//        CollectCoins.gameObject.SetActive(false);
//
//        sprite[coincount].SetActive(false);//denne fjerner det nåværende bilde
//        coincount++;                         //den sier at neste bilde skal legges til, altså at den neste som er lagret i arrayen er i scena. 
//        sprite[coincount].SetActive(true);  //denne setter det bilde som ble lagt til som aktiv.
//                                            //med dette så ser man bare det aktive bildet som er skrudd på til slutt. 
//                                            //Dette looper rundt for hver gang man colliderer med tag "Coin"
//    }
//}

//Shouldn't be able to drag another item on another when in crafting