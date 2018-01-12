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
    public bool onslot1 = false;
    public bool onslot2 = false;
    private bool justonslot = false;
    public bool twoinslot = false;
    private float distance;
    private Vector2 distancebetweenobj;

    private Inventory inv;
    //public Vector3 orgpos;
    public Vector3 orgpos2;
    public RectTransform rect;


    //public GameObject other;

    // public GameObject plass1;
    // public GameObject plass2;
    // public GameObject plass3;

    private bool sal;
    // Use this for initialization
    void Start()
    {
        inv = FindObjectOfType<Inventory>();

       // orgpos = transform.position;
        orgpos2 = transform.localPosition;
       
        // thisobj = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (test && !onslot1 && !onslot2)
        {
            //I'm not sure why I have to use localPosition in this case. Like kinda do. It has to move within in the canvas space, not world. 
            transform.localPosition = orgpos2;
            //transform.position = orgpos;
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
        test = true;
        dragging = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slot1"))
        {
            onslot1 = true;
            transform.position = slot1.transform.position;
            if (!justonslot)
                StartCoroutine(MoveItemAgain());
            //set to this slot position
        }
        if (collision.gameObject.CompareTag("Slot2"))
        {
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
            onslot1 = false;
            justonslot = false;
            //move it back into right place in inventory. 
            //transform.position = orgpos;
        }
        if(collision.gameObject.CompareTag("Slot2"))
        {
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

}
