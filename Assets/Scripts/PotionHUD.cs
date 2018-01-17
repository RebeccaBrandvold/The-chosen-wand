using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class PotionHUD : MonoBehaviour, IPointerDownHandler
{
    public GameObject InventoryPotion;
    public GameObject otherInv;
    public bool PotionInvOn = false;

    private ClickBag bag;
    // Use this for initialization
    void Start () {
        bag = FindObjectOfType<ClickBag>();
	}

	// Update is called once per frame
	void Update ()
    {
        if (PotionInvOn)
        {
            if (bag.InventoryOn)
            {
                bag.Inventory.SetActive(false);
                //bag.InventoryOn = false;
            }
            //otherInv.SetActive(false);
            InventoryPotion.SetActive(true);
        }
        else
            InventoryPotion.SetActive(false);

    }
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.CompareTag("Potion"))
        {
            bag.InventoryOn = false;
            PotionInvOn = !PotionInvOn;
        }
    }
}
