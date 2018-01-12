using UnityEngine;
using System.Collections;

public class Slot2_check : MonoBehaviour {

    public bool rogn = false;
    public bool kantarell = false;
    public bool salmon = false;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
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
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
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
    }
}
