using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public GameObject thisObj;
    public float speed = 3;
    public Transform target;

    private Vector3 pos;
    private bool notmoving = false;

    //private Rigidbody2D rb;

    void Start()
    {
        //thisObj = this.GetComponent<GameObject>();
        pos = transform.position;
        //rb = GetComponent<Rigidbody2D>();
    }   

    void Update()
    {
        float step = speed * Time.deltaTime;

        if (!notmoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }

    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Companion"))
        {
            notmoving = true;
            transform.position = pos;
            // thisObj.SetActive(false);
            yield return new WaitForSeconds(3);
            //thisObj.SetActive(true);
            notmoving = false;
        }
    }
}
