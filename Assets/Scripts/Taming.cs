using UnityEngine;
using System.Collections;

public class Taming : MonoBehaviour
{
    public GameObject tamingmenu;

    void Start () {
	
	}
	

	void Update ()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            tamingmenu.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tamingmenu.SetActive(false);
        }
    }
}

