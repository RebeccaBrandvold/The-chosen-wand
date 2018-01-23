using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Drag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //The slots on the menu where the item is placed
    public GameObject slot1;
    public GameObject slot2;
    //How long to wait before you can move the item again. 
    //Need it to set the item into place automatically, so the player can't move it before this. 
    public float waittime = 0.5f;

    //Are we dragging the object?
    public bool dragging = false;
    //The distance from the obj to the camera
    private float distance;
    //Are we one of the slots?
    public bool onslot = false;
    //These variables will let the item teleport to the slot when inside there. 
    public bool onslot1 = false;
    public bool onslot2 = false;
    private bool justonslot = false;

    public Vector3 orgpos2;
    private Slot1_Check slot1_scrp;
    private Slot2_check slot2_scrp;
    private Taming taming;
    private Crafting craft;

    public GameObject[] item = new GameObject[6];
    //Dum måte å gjøre det på, gjør det likevel
    private Vector3 orgposRogn;
    private Vector3 orgposSalmon;
    private Vector3 orgposKantarell;
    private Vector3 orgposRosered;
    private Vector3 orgposRoseyellow;
    private Vector3 orgposStone;

    public bool stopchanesfromdropping = false;

    void Start()
    {
        craft = FindObjectOfType<Crafting>();
        taming = FindObjectOfType<Taming>();
        slot1_scrp = FindObjectOfType<Slot1_Check>();
        slot2_scrp = FindObjectOfType<Slot2_check>();
        orgpos2 = transform.localPosition;
        orgposRogn = item[0].transform.localPosition;
        orgposKantarell = item[1].transform.localPosition;
        orgposSalmon = item[2].transform.localPosition;

        orgposRosered = item[3].transform.localPosition;
        orgposRoseyellow = item[4].transform.localPosition;
        orgposStone = item[5].transform.localPosition;
    }

    void Update()
    {
        //Supposed to make the items on the slot move back to orgpos if the menu is gone
        //if (!taming.withinRange)
        //{
        //    transform.localPosition = orgpos2;
        //}
      // if(taming.returntoInv)
      // {
      //     transform.localPosition = orgpos2;
      // }
        //If you are not on any of the slots, move it to the inventory. 
        if (!onslot1 && !onslot2)
        {
            //It has to move within in the canvas space, not world, why we use local. 
            transform.localPosition = orgpos2;
        }
        //Moves the items back to the inventory if they combined two ingriedents wrong.
        //Right now, these scripts are turned inactive as you are not near the animal
        //This leads to that the this script can't find this, causing an error. 
        if (slot1_scrp.onetry && slot2_scrp.onetry && !stopchanesfromdropping)
        {
            StartCoroutine(WrongCombination());
            stopchanesfromdropping = true;
        }
        //If moving object
        if (dragging)
        {
            //as long as you are not on a slot, you can move the item. 
            //This bool will turn false after a short time, allowing the object to move quickly after. 
            if (!onslot)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Vector3 rayPoint = ray.GetPoint(distance);
                transform.position = rayPoint;
            }
        }

    }
    //for other objects than UI objects
    // void OnMouseDown()
    // {
    //     distance = Vector3.Distance(transform.position, Camera.main.transform.position);
    //     dragging = true;
    // }
    //
    // void OnMouseUp()
    // {
    //     dragging = false;
    // }

    //Function used to detect if you have clicked on an UI element
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        //Calculate the distance between this obj and the camera. 
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }
    //If releasing mousebutton, we are not moving the object anymore
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
    }

private void OnTriggerEnter2D(Collider2D collision)
    {
        //If this object collided with slot1 big trigger box, move it automatically to it's position. 
        //Feels like its locking onto the slot.
        if (collision.gameObject.CompareTag("Slot1"))
        {
            //This method almost worked, but the problem with this one is that the slot registers that
            //it is occupied, but when you then switch the things, the object going out is telling the slot
            //that it is not occupied anymore! 
           //  if (slot1_scrp.occupied)
           //  {
           //      slot1_scrp.curitem.transform.localPosition = orgpos2;
           //     test = true;
           //  }

            //if it is occupied, replace the new item with the old one.
            if (slot1_scrp.rogn)
                {
                    item[0].transform.localPosition = orgposRogn;
                }
                if (slot1_scrp.kantarell)
                {
                    item[1].transform.localPosition = orgposKantarell;
                }
                if (slot1_scrp.salmon)
                {
                    item[2].transform.localPosition = orgposSalmon;
                }
                if (slot1_scrp.rose_red)
                {
                    item[3].transform.localPosition = orgposRosered;
                }
                if (slot1_scrp.rose_yellow)
                {
                    item[4].transform.localPosition = orgposRoseyellow;
                }
                if (slot1_scrp.stone)
                {
                    item[5].transform.localPosition = orgposStone;
                }
            transform.position = slot1.transform.position;

            onslot1 = true;
            //if you have not already been locked onto the slot, you can move like normal again.
            if (!justonslot)
                StartCoroutine(MoveItemAgain());
        }

        //Same with slot1, just with slot2
        if (collision.gameObject.CompareTag("Slot2"))
        {
            if (slot2_scrp.rogn)
            {
                item[0].transform.localPosition = orgposRogn;
            }
            if (slot2_scrp.kantarell)
            {
                item[1].transform.localPosition = orgposKantarell;
            }
            if (slot2_scrp.salmon)
            {
                item[2].transform.localPosition = orgposSalmon;
            }
            if (slot2_scrp.rose_red)
            {
                item[3].transform.localPosition = orgposRosered;
            }
            if (slot2_scrp.rose_yellow)
            {
                item[4].transform.localPosition = orgposRoseyellow;
            }
            if (slot2_scrp.stone)
            {
                item[5].transform.localPosition = orgposStone;
            }

            transform.position = slot2.transform.position;
            onslot2 = true;
            if (!justonslot)
                StartCoroutine(MoveItemAgain());
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //If not on that slot anymore, turn things false so that things can restart.
        //Meaning, you can lock onto slot again and detect again if the obj should be moved to inventory
        if (collision.gameObject.CompareTag("Slot1"))
        {
            //test = false;
            //occupied = false;
            onslot1 = false;
            justonslot = false;
            //move it back into right place in inventory. 
            //transform.position = orgpos;
        }
        if (collision.gameObject.CompareTag("Slot2"))
        {
            //occupied2 = false;
            onslot2 = false;
            justonslot = false;
        }

    }
    //A function that makes it impossible to move the item through mouse dragging for a short period of time.
    //Needed that to make sure the object can be locked onto the slot, and then moved normally again.
    private IEnumerator MoveItemAgain()
    {
        onslot = true;
        yield return new WaitForSeconds(waittime);
        onslot = false;
        justonslot = true;
    }
    //If there was a wrong combination, this will reset the items to the inventory.
    private IEnumerator WrongCombination()
    {
        yield return new WaitForSeconds(0.2f);
        transform.localPosition = orgpos2;
    }

}
