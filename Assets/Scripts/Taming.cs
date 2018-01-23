using UnityEngine;
using System.Collections;

public class Taming : MonoBehaviour
{
    public GameObject tamingmenu;

    private Crafting craft;
    //private Drag drag;
    public bool returntoInv = false;
    private bool exited = false;
    public bool withinRange = false;

    void Start()
    {
        craft = FindObjectOfType<Crafting>();
        //drag = FindObjectOfType<Drag>();
        //I don't know why but for some reason, turning this off, makes it impossible to move SOME of the 
        //items. 
        //tamingmenu.SetActive(false);

    }

    //If the menu is off, the all the items there should be returned to inventory. 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //withinRange = false;
            returntoInv = true;
            tamingmenu.SetActive(false);
        }
        if (craft.lost)
        {
            withinRange = false;
            tamingmenu.SetActive(false);
            returntoInv = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && withinRange)
        {
            returntoInv = false;
            tamingmenu.SetActive(true);
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            returntoInv = false;
            withinRange = true;
            if (!craft.lost && !exited)
                tamingmenu.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            returntoInv = true;
            withinRange = false;
            tamingmenu.SetActive(false);
            exited = false;
        }
    }
}

