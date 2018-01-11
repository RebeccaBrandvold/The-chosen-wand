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
 
    private bool dragging = false;
    public bool onslot = false;
    private bool justonslot = false;
    public bool twoinslot = false;
    private float distance;
    private Vector2 distancebetweenobj;

    public GameObject other;

    public GameObject plass1;
    public GameObject plass2;
    public GameObject plass3;
    public GameObject rogn;
    public GameObject kantarell;
    public GameObject Salmon;

    // Use this for initialization
    void Start ()
    {

       // thisobj = GetComponent<GameObject>();
    }
	
	// Update is called once per frame
	void Update ()
    {
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

    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;
    }

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
            transform.position = slot1.transform.position;
            if(!justonslot)
            StartCoroutine(MoveItemAgain());
            //rgbcon = RigidbodyConstraints2D.FreezeAll;
            //set to this slot position
        }
        if (collision.gameObject.CompareTag("Slot2"))
        {
            transform.position = slot2.transform.position;
            if (!justonslot)
                StartCoroutine(MoveItemAgain());
            //rgbcon = RigidbodyConstraints2D.FreezeAll;
            //set to this slot position
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slot1") || collision.gameObject.CompareTag("Slot2"))
        {
            justonslot = false;
            //move it back into right place in inventory. 
            //transform.position = orgpos;
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
