using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

//public class Inv_items : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
public class Inv_items : MonoBehaviour
{
    //The drag class, which won't work for some reason
   // private Drag drag;
   //
   // private float distance;
   // private bool dragging = false;
   // private void Start()
   // {
   //     drag = FindObjectOfType<Drag>();
   // }
   //
   // private void Update()
   // {
   //     if (dragging)
   //     {
   //        if (!drag.onslot)
   //        {
   //             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
   //             Vector3 rayPoint = ray.GetPoint(distance);
   //             transform.position = rayPoint;
   //         }
   //     }
   // }
   // void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
   // {
   //     distance = Vector3.Distance(transform.position, Camera.main.transform.position);
   //     dragging = true;
   // }
   // void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
   // {
   //     dragging = false;
   // }
    // public GameObject slot1;
    // public GameObject slot2;
    //
    // public float waittime = 0.5f;
    //
    // private bool dragging = false;
    // public bool onslot = false;
    // public bool onslot1 = false;
    // public bool onslot2 = false;
    // public bool justonslot = false;
    // private float distance;
    // public Vector3 orgpos2;
    //
    // private Slot1_Check slot1_scrp;
    // private Slot2_check slot2_scrp;
    // // Use this for initialization
    // void Start ()
    // {
    //     slot1_scrp = FindObjectOfType<Slot1_Check>();
    //     slot2_scrp = FindObjectOfType<Slot2_check>();
    //     orgpos2 = transform.localPosition;
    //
    // }
    //
    //// Update is called once per frame
    //void Update ()
    // {
    //     if (!onslot1 && !onslot2)
    //     {
    //         //I'm not sure why I have to use localPosition in this case. Like kinda do. It has to move within in the canvas space, not world. 
    //         transform.localPosition = orgpos2;
    //         //transform.position = orgpos;
    //     }
    //
    //     if (slot1_scrp.onetry && slot2_scrp)
    //     {
    //         StartCoroutine(WrongCombination());
    //     }
    //
    // }
    //
    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Slot1"))
    //     {
    //         // if (test)
    //         // {
    //         onslot1 = true;
    //         transform.position = slot1.transform.position;
    //         if (!justonslot)
    //             StartCoroutine(MoveItemAgain());
    //         // }
    //         //set to this slot position
    //     }
    //     if (collision.gameObject.CompareTag("Slot2"))
    //     {
    //         onslot2 = true;
    //         //transform.position = slot2.transform.position;
    //         if (!justonslot)
    //             StartCoroutine(MoveItemAgain());
    //     }
    //
    // }
    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Slot1"))
    //     {
    //         onslot1 = false;
    //         justonslot = false;
    //         //move it back into right place in inventory. 
    //         //transform.position = orgpos;
    //     }
    //     if (collision.gameObject.CompareTag("Slot2"))
    //     {
    //         onslot2 = false;
    //         justonslot = false;
    //     }
    //
    // }
    // private IEnumerator MoveItemAgain()
    // {
    //     onslot = true;
    //     yield return new WaitForSeconds(waittime);
    //     onslot = false;
    //     justonslot = true;
    // }
    // private IEnumerator WrongCombination()
    // {
    //     yield return new WaitForSeconds(0.5f);
    //     transform.localPosition = orgpos2;
    // }
    //(0.5f);
    //     transform.localPosition = orgpos2;
    // }
}
