using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inventory : MonoBehaviour
{
    public GameObject[] items = new GameObject[3];
    private Crafting craft;
    private bool changesprite = false;
    private bool changesprite1 = false;
    private bool changesprite2 = false;
    //an item in inventory.
    public Image image;
    public Sprite sprite;

    public Image image1;
    public Sprite sprite1;

    public Image image2;
    public Sprite sprite2;

    public bool unlockRogn = false;
    public bool unlockKant = false;
    public bool unlockSalmon = false;

    public GameObject rogn;
    public GameObject kantarell;
    public GameObject salmon;

    public int count = 0;
	void Start ()
    {
        craft = FindObjectOfType<Crafting>();
        kantarell.GetComponent<Drag>().enabled = false;
        rogn.GetComponent<Drag>().enabled = false;
        salmon.GetComponent<Drag>().enabled = false;
    }
	
	// Update is called once per frame

	void Update ()
    {
        if(changesprite)
            image.sprite = sprite;
        if (changesprite1)
            image1.sprite = sprite1;
        if (changesprite2)
            image2.sprite = sprite2;

        //turn sprites black when they have used the item. 

        //    if (craft.changing)
        //        items[0].SetActive(false);
        //    if (craft.changing1)
        //        items[1].SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision here is player
        //one way is to let every item have their own unique tag. But should think of something where they have it in common. Probably have to get the component or similiar. Or a bool?
        // if(collision.gameObject.CompareTag("Items"))
        // {
        //     //An inventory where the items have a set place
        //     items[count].SetActive(true);
        //     collision.gameObject.SetActive(false);
        //     count++;
        // }
        //A way to see the silhoutte in inventory. 
        if (collision.gameObject.CompareTag("Rogn"))
        {
            rogn.GetComponent<Drag>().enabled = true;
            unlockRogn = true;
            items[1].SetActive(false);
            changesprite1 = true;
        }
        if (collision.gameObject.CompareTag("Kantarell"))
        {
            kantarell.GetComponent<Drag>().enabled = true;
            unlockKant = true;
            items[0].SetActive(false);
            changesprite = true;
        }

        if (collision.gameObject.CompareTag("Salmon"))
        {
           salmon.GetComponent<Drag>().enabled = true;
            unlockSalmon = true;
            items[2].SetActive(false);
            changesprite2 = true;
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