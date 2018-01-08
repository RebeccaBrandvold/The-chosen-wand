using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//Handles everything in the invetory

public class Inventory : MonoBehaviour {
    public int slotX, slotY;
    public List<Item> inventory = new List<Item>();
    public List<Item> slots = new List<Item>();
    private ItemDatabase database;
    private bool showInventory;

    private bool showToolTip;
    private string tooltip;

    public GUISkin skin; //Define the whole skin for all of the gui elements. 

	// Use this for initialization
	void Start () {
        for (int i = 0; i < (slotX * slotY); i ++)
        {
            slots.Add(new Item());
            inventory.Add(new Item());//adds item to inventory??
        }
        // inventory.Add(); //Add items to the inventory
        database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
        AddItem(1);//Add item
        AddItem(0);
        RemoveItem(0);//remove
       // print(InventoryContains(1));//test if holds item
    }
	void Update()
    {
        if(Input.GetButtonDown("Inventory"))
        {
            showInventory = !showInventory;//when clicked i it changes to the oposit of whatever it is
        }
    }
	void OnGUI()
    {
        tooltip = " ";
        GUI.skin = skin;
        if(showInventory)
        {
            DrawInventory();//drawinv can now use gui
        }
        if(showToolTip)
        {
            GUI.Box(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 200, 200), tooltip);
        }
    }

    void RemoveItem(int id)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemID == id)
            {
                inventory[i] = new Item();//replaces with with empty item.
                break;
            }
        }
    }
    void DrawInventory()
    {
        int i = 0;
        for (int y = 0; y < slotY; y++)
        {
            for (int x = 0; x < slotX; x++)
            {//where its put on screen
                //will hold the rectangle of the slot
                Rect slotRect = new Rect(x * 60, y * 60, 50, 50);
                GUI.Box(slotRect, "",skin.GetStyle("Slot"));
                slots[i] = inventory[i];
                if(slots[i].itemName != null)
                {
                    GUI.DrawTexture(slotRect, slots[i].itemIcon);
                    //check if mouse is over this slot by using mouse position
                    if(slotRect.Contains(Event.current.mousePosition))//contains takes a position and sees if that position ends up in that rectangle position
                    {
                        tooltip = CreateTooltip(slots[i]);
                        showToolTip = true;
                    }
                }
                i++;
            }
        }
    }

    string CreateTooltip(Item item)
    {
        tooltip = item.itemName;
        return tooltip;
        
    }

    void AddItem(int id)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemName == null)
            {
                for(int j = 0;j < database.items.Count; j++)
                {
                    if (database.items[j].itemID == id)
                    {
                        inventory[i] = database.items[j]; //can change the items in the inv wihtout messing up because it goes with the ID not the spot in the array.
                    }
                }
                break;
            }
        }
    }


    bool InventoryContains(int id)//checking item based on id
    {
        bool result = false; //store true or false based on what it is
        for(int i = 0; i < inventory.Count; i++)
        {
            result = inventory[i].itemID == id;
            if (result)
            {
                break;
            }
        }
        return result;
    }
}
