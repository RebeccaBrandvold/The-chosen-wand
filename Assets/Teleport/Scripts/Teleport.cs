using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour
{
    public GameObject too;
    public bool transported = false;
    public bool move = false;
    public Transform animal;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            animal.transform.position = too.transform.position;
        }
        if (transported)
        {
            animal.gameObject.SetActive(true);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Animal"))
        {

            animal = collision.transform;
            //animal = collision.gameObject.GetComponent<GameObject>();
            move = true;
            // collision.gameObject.SetActive(false);
            //animal.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            transported = true;
            move = false;
        }
        // if (collision.gameObject.CompareTag("Player"))
        // {
        //     Debug.Log("Player crashed");
        //     animal.gameObject.SetActive(true);
        //     move = false;
        //     transported = true;
        //     //collision.gameObject.SetActive(true);
        // }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //animal.gameObject.SetActive(true);
            transported = false;
        }
    }

}
