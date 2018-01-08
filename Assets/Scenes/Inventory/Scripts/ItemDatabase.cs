using UnityEngine;
using System.Collections;
using System.Collections.Generic;//Access to List

public class ItemDatabase : MonoBehaviour {
    //defines datatype in list
    public List<Item> items = new List<Item>(); //Creates the list item Just like we did in 3D

    void start()
    {
        items.Add(new Item("iconsitem_0", 0, "blablaba", 0, 0, Item.ItemType.Crafting));
        items.Add(new Item("iconsitem_1", 1, "blablaba", 0, 0, Item.ItemType.Crafting));

    }

}
