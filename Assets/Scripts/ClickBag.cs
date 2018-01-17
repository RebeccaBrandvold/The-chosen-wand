using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ClickBag : MonoBehaviour, IPointerDownHandler
{
    public GameObject Inventory;
    public GameObject otherInv;

    public bool InventoryOn = false;

    private PotionHUD potion;
	// Use this for initialization
	void Start ()
    {
        potion = FindObjectOfType<PotionHUD>();
	}
	//They are stopping each other from popping up. 
	// Update is called once per frame
	void Update ()
    {
        if (InventoryOn)
        {
            if(potion.PotionInvOn)
            {
                potion.InventoryPotion.SetActive(false);
                //potion.PotionInvOn = !potion.InventoryPotion;
            }
            //otherInv.SetActive(false);
            Inventory.SetActive(true);
        }
        else
            Inventory.SetActive(false);

        //A way to do it
        //gameObject.GetComponentInChildren<GameObject>().CompareTag("Potion");
	
	}

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.CompareTag("Bag"))
        {
            potion.PotionInvOn = false;
            InventoryOn = !InventoryOn;
        }
    }
}
