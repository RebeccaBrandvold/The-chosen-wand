using UnityEngine;
using System.Collections;

//Holds the items names description?? idk?? idkdidkdidkikd??
[System.Serializable]
public class Item : MonoBehaviour{

    //Name of the item
    public string itemName;
    public int itemID;//When you want to add item to inv you can just say add 5 instead of name
    public string itemDesc; //intem description?
    //Icon for the item
    public Texture2D itemIcon;

    public int itemPower;//Stats
    public int itemSpeed;//Stats for somethingidk

     public ItemType itemType; //refering to ItemType

    //own selection of data type. 
     public enum ItemType    {
        //Defining a type
        Boost, 
        Crafting
    }

    //constructor for the item  //name of icon same as name
    public Item(string name, int id, string desc, int power, int speed, ItemType type)//is called whenver this class is called
    {
        itemName = name;//Asignt value to value
        itemID = id;
        itemDesc = desc;
        itemIcon = Resources.Load<Texture2D>("Item Icons/" + name);//finds the folder .

        itemPower = power;
        itemSpeed = speed;
        itemType = type;
        
    }

    public Item ()
    {

    }
}
