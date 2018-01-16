using UnityEngine;
using System.Collections;

public class Slot2_check : MonoBehaviour {

    public bool rogn = false;
    public bool kantarell = false;
    public bool salmon = false;
    public bool rose_red = false;
    public bool rose_yellow = false;
    public bool stone = false;
    public bool tried = false;
    public bool onetry = false;
    public bool occupied = false;
    public bool occupied2 = false;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Items"))
        {
            // onetry = true;
            occupied2 = true;
            tried = true;
        }
        if (collision.gameObject.CompareTag("Rogn"))
        {
            rogn = true;
        }
        if (collision.gameObject.CompareTag("Kantarell"))
        {
            kantarell = true;
        }
        if (collision.gameObject.CompareTag("Salmon"))
        {
            salmon = true;
        }
        if (collision.gameObject.CompareTag("Rose_red"))
        {
            rose_red = true;
        }
        if (collision.gameObject.CompareTag("Rose_yellow"))
        {
            rose_yellow = true;
        }
        if (collision.gameObject.CompareTag("Stone"))
        {
            stone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Items"))
        {
            onetry = false;
            tried = false;
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
