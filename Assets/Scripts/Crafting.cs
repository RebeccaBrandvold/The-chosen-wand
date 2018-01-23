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
    public float chances = 3;

    public bool lost = false;
    private Drag drag;
    private Slot1_Check check1;
    private Slot2_check check2;
    private bool slot1fill = false;
    private bool slot2fill = false;

    public Image image;
    public Sprite sprite;

    public GameObject[] itemtodel = new GameObject[2];
    public bool unlocked = false;


    void Start()
    {
        check1 = FindObjectOfType<Slot1_Check>();
        check2 = FindObjectOfType<Slot2_check>();
        drag = FindObjectOfType<Drag>();

    }

    void Update()
    {
        if(chances <= 0)
        {
            lost = true;
            Debug.Log("You used up all your chances");
        }
        //The winning conditions
        if (check1.kantarell && check2.salmon && !lost)
        {
            unlocked = true;
            image.sprite = sprite;
            Debug.Log("Yes, correct");
            itemtodel[0].SetActive(false);
            itemtodel[1].SetActive(false);
        }
        else if (check1.salmon && check2.kantarell && !lost)
        {
            unlocked = true;
            image.sprite = sprite;
            itemtodel[0].SetActive(false);
            itemtodel[1].SetActive(false);
            Debug.Log("yEAH, WHATEVER");
        }
        if(check1.occupied && check2.occupied2)
        {
            chances = chances - 1;
        }

        //DO NOT DO THIS. Turning these true does so that you can move the items, since an if is dependent that they
        //turn true in slot1_check and slot2.
        //else if(!check1.onetry && !check2.onetry)
        //{
        //    chances--;
        //    check1.onetry = true;
        //    check2.onetry = true;
        //}
        //The items have empty gameobjects with the tag items and this we can use to check if we have tried an item.


    }

    //must have a rigidbody to the objects you want to collide
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision here is the image of the result 
        //check the slots if there is both kantarell and rogn in each of them. Shouldn't matter which one
    }

}