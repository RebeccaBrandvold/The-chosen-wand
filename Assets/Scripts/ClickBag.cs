using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ClickBag : MonoBehaviour, IPointerDownHandler
{
    public GameObject Inventory;
    public GameObject otherInv;

    public bool InventoryOn = true;

    private PotionHUD potion;

	void Start ()
    {
        potion = FindObjectOfType<PotionHUD>();
	}

	void Update ()
    {
        if (InventoryOn)
        {
            if(potion.PotionInvOn)
            {
                potion.InventoryPotion.SetActive(false);
            }
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
