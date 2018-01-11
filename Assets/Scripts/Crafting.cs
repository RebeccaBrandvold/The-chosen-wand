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

    private GameObject Kantarell;
    private GameObject Salmon;
    private GameObject Rogn;

    public Image image;
    public Sprite sprite;

    void Start()
    {
        check1 = FindObjectOfType<Slot1_Check>();
        check2 = FindObjectOfType<Slot2_check>();
        curitem = FindObjectOfType<Drag>();
        Kantarell = GameObject.FindGameObjectWithTag("Kantarell");
        Salmon = GameObject.FindGameObjectWithTag("Salmon");
        Rogn = GameObject.FindGameObjectWithTag("Rogn");
    }

    void Update()
    {
        if (check1.kantarell && check2.salmon)
        {
            image.sprite = sprite;
            Debug.Log("Yes, correct");
        }
        else if (check2.kantarell && check2.salmon)
        {
            image.sprite = sprite;
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