﻿using UnityEngine;
using System.Collections;

public class Spot1 : MonoBehaviour
{
    public GameObject firstSpot;//i changed name
    public GameObject backSpot;//me
    public Transform animal;
    private bool move = false;
    public bool justtransported = false;

    private Spot2 spot2;

    public static float AngleDir(Vector2 A, Vector2 B)// TO CHECK IF RIGHT OR LEFT this is for 2D 
    {
        return -A.x * B.y + A.y * B.x;//This returns a negative number if B is left of A, positive if right of A, or 0 if they are perfectly aligned.
    }

    



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
            animal.position = firstSpot.transform.position;
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
