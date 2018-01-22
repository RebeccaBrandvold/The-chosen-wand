using UnityEngine;
using System.Collections;

public class Spot2 : MonoBehaviour
{
    public GameObject firstSpot;
    public GameObject backSpot;
    public Transform animal;
    public bool move = false;
    public bool justtransported = false;

    private Spot1 spot1;

    // Use this for initialization
    void Start()
    {
        spot1 = FindObjectOfType<Spot1>();
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            animal.position = firstSpot.transform.position;
            move = false;
            justtransported = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            spot1.animal.gameObject.SetActive(true);
        }
        
        if (!spot1.justtransported)
        {
            if (collision.gameObject.CompareTag("Animal"))
            {
                animal = collision.transform;
                animal.gameObject.SetActive(false);
                move = true;
            }
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Animal"))
        {
            spot1.justtransported = false;
        }
    }
}
