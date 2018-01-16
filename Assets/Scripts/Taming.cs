using UnityEngine;
using System.Collections;

public class Taming : MonoBehaviour
{
    public GameObject tamingmenu;

    private Crafting craft;

    void Start()
    {
        craft = FindObjectOfType<Crafting>();

    }


    void Update()
    {
        if (craft.lost)
            tamingmenu.SetActive(false);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!craft.lost)
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

