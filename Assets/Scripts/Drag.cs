using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Drag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public GameObject slot1;
    public GameObject slot2;

    public float waittime = 0.5f;
    public bool test = false;

    private bool dragging = false;
    public bool onslot = false;
    //These variables will let the item teleport to the slot when inside there. 
    public bool onslot1 = false;
    public bool onslot2 = false;
    private bool justonslot = false;
    private bool teleporttoslot = false;
    public bool twoinslot = false;
    private float distance;
    private Vector2 distancebetweenobj;

    private Inventory inv;
    //public Vector3 orgpos;
    public Vector3 orgpos2;
    public RectTransform rect;
    private Slot1_Check slot1_scrp;
    private Slot2_check slot2_scrp;

    //public GameObject other;

    public GameObject[] item = new GameObject[6];
    //Dum måte å gjøre det på, gjør det likevel
    private Vector3 orgposRogn;
    private Vector3 orgposSalmon;
    private Vector3 orgposKantarell;
    private Vector3 orgposRosered;
    private Vector3 orgposRoseyellow;
    private Vector3 orgposStone;

    private bool sal;
    // Use this for initialization
    void Start()
    {
        inv = FindObjectOfType<Inventory>();
        slot1_scrp = FindObjectOfType<Slot1_Check>();
        slot2_scrp = FindObjectOfType<Slot2_check>();
        // orgpos = transform.position;
        orgpos2 = transform.localPosition;
        orgposRogn = item[0].transform.localPosition;
        orgposSalmon = item[1].transform.localPosition;
        orgposKantarell = item[2].transform.localPosition;

        orgposRosered = item[3].transform.localPosition;
        orgposRoseyellow = item[4].transform.localPosition;
        orgposStone = item[5].transform.localPosition;


        // thisobj = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!onslot1 && !onslot2)
        {
            //I'm not sure why I have to use localPosition in this case. Like kinda do. It has to move within in the canvas space, not world. 
            transform.localPosition = orgpos2;
            //transform.position = orgpos;
        }
        //Moves the items back to the inventory if they combined two ingriedents wrong
        if (slot1_scrp.onetry && slot2_scrp)
        {
            StartCoroutine(WrongCombination());
        }

        //apparently, I can't make the bug work again so kinda useless. Supposed to solve how to decide which object is in front of the other. 
        // Vector2 forward = transform.TransformDirection(Vector3.forward);
        // distancebetweenobj = other.transform.position - transform.position;
        // if(Vector2.Dot(forward, distancebetweenobj) < 0)
        // {
        //     //this obj is ahead
        //     Debug.Log("current obj is ahead");
        // }
        // else if(Vector2.Dot(forward, distancebetweenobj) > 0)
        // {
        //     //other obj is ahead
        // }
        // else
        //they are side by side, rettvinklet på hverandre
        //Debug.Log(slot1.GetInstanceID());

        if (dragging)
        {
            if (!onslot)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Vector3 rayPoint = ray.GetPoint(distance);
                transform.position = rayPoint;
            }
        }

        // if (teleporttoslot)
        //     transform.position = slot2.transform.position;

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

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slot1"))
        {
            //if it is occupied, replace the new item with the old one. This creates problems. 
            if (slot1_scrp.occupied)
            {
                transform.position = slot1.transform.position;
                if (slot1_scrp.rogn)
                    item[0].transform.position = orgposRogn;
                else if (slot1_scrp.salmon)
                    item[1].transform.position = orgposSalmon;
                else if (slot1_scrp.kantarell)
                    item[2].transform.position = orgposKantarell;
                else if (slot1_scrp.rose_red)
                    item[3].transform.position = orgposRosered;
                else if (slot1_scrp.rose_yellow)
                    item[4].transform.position = orgposRoseyellow;
                else if (slot1_scrp.stone)
                    item[5].transform.position = orgposStone;
            }
            else
                transform.position = slot1.transform.position;


            onslot1 = true;
            if (!justonslot)
                StartCoroutine(MoveItemAgain());
            // }
            //set to this slot position
        }
        if (collision.gameObject.CompareTag("Slot2"))
        {
          //  if (!slot2_scrp.occupied2)
          //  {
                transform.position = slot2.transform.position;
            //
            onslot2 = true;
            transform.position = slot2.transform.position;
            if (!justonslot)
                StartCoroutine(MoveItemAgain());
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slot1"))
        {
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
    private IEnumerator MoveItemAgain()
    {
        onslot = true;
        yield return new WaitForSeconds(waittime);
        onslot = false;
        justonslot = true;
    }
    private IEnumerator WrongCombination()
    {
        yield return new WaitForSeconds(0.5f);
        transform.localPosition = orgpos2;
    }

}
