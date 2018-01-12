using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{

    //For this we'll be making different scripts according to which animal we're taming at the moment. So this can for instance be called craft_fox or smth.
    public GameObject rightitem;
    public GameObject rightitem2;
    public GameObject slot2;
    public GameObject slot1;

    private Drag curitem;
    private Slot1_Check check1;
    private Slot2_check check2;
    private bool slot1fill = false;
    private bool slot2fill = false;

    public Image image;
    public Sprite sprite;

    public GameObject[] itemtodel = new GameObject[2];

    void Start()
    {
        check1 = FindObjectOfType<Slot1_Check>();
        check2 = FindObjectOfType<Slot2_check>();
        curitem = FindObjectOfType<Drag>();

    }

    void Update()
    {
        if (check1.kantarell && check2.salmon)
        {
            image.sprite = sprite;
            Debug.Log("Yes, correct");
            itemtodel[0].SetActive(false);
            itemtodel[1].SetActive(false);
        }
        else if (check1.salmon && check2.kantarell)
        {
            image.sprite = sprite;
            itemtodel[0].SetActive(false);
            itemtodel[1].SetActive(false);
            Debug.Log("yEAH, WHATEVER");
        }
        else if(check1.rogn || check2.rogn)
            Debug.Log("Not correct");
    }

    //must have a rigidbody to the objects you want to collide
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision here is the image of the result 
        //check the slots if there is both kantarell and rogn in each of them. Shouldn't matter which one
    }

}