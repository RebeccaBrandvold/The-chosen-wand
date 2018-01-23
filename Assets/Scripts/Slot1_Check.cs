using UnityEngine;
using System.Collections;

public class Slot1_Check : MonoBehaviour {

    public bool rogn = false;
    public bool kantarell = false;
    public bool salmon = false;
    public bool rose_red = false;
    public bool rose_yellow = false;
    public bool stone = false;
    public bool occupied = false;
    public bool occupied2 = false;
    public bool item = false;
    public Transform curitem;

    private Slot2_check slot2;
    private Drag drag;

    //public GameObject[] invItems = new GameObject[6];

    //kunne ha lagd et script som har kontroll på alle de posisjonen
    private Vector3 orgposRogn;

    public bool onetry = false;

    void Start ()
    {
        slot2 = FindObjectOfType<Slot2_check>();
        drag = FindObjectOfType<Drag>();
	}
	

	void Update ()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Items"))
        {
            occupied = true;
               onetry = true;
        }
        if (collision.gameObject.CompareTag("Rogn"))
        {
            //get the collider on which you crashed
            curitem = collision.transform;
            rogn = true;
        }
        if (collision.gameObject.CompareTag("Kantarell"))
        {
            curitem = collision.transform;
            kantarell = true;
        }
        if (collision.gameObject.CompareTag("Salmon"))
        {
            curitem = collision.transform;
            salmon = true;
        }
        if (collision.gameObject.CompareTag("Rose_red"))
        {
            curitem = collision.transform;
            rose_red = true;
        }
        if (collision.gameObject.CompareTag("Rose_yellow"))
        {
            curitem = collision.transform;
            rose_yellow = true;
        }
        if (collision.gameObject.CompareTag("Stone"))
        {
            curitem = collision.transform;
            stone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Items"))
        {
            //if(!drag.test)
            occupied = false;
            onetry = false;
        }
        if (collision.gameObject.CompareTag("Rogn"))
        {
            rogn = false;
        }
        if (collision.gameObject.CompareTag("Kantarell"))
        {
            kantarell = false;
        }
        if (collision.gameObject.CompareTag("Salmon"))
        {
            salmon = false;
        }
        if (collision.gameObject.CompareTag("Rose_red"))
        {
            rose_red = false;
        }
        if (collision.gameObject.CompareTag("Rose_yellow"))
        {
            rose_yellow = false;
        }
        if (collision.gameObject.CompareTag("Stone"))
        {
            stone = false;
        }
    }


}
