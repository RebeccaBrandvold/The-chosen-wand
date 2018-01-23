using UnityEngine;
using System.Collections;

public class Spot1 : MonoBehaviour
{
    public GameObject otherspot;
    public Transform animal;
    private bool move = false;
    public bool justtransported = false;

    private Spot2 spot2;
    // Use this for initialization
    void Start()
    {
        spot2 = FindObjectOfType<Spot2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            animal.position = otherspot.transform.position;
            move = false;
            justtransported = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spot2.animal.gameObject.SetActive(true);
        }
        if (!spot2.justtransported)
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
            spot2.justtransported = false;
        }
    }
}
