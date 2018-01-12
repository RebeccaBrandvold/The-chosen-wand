using UnityEngine;
using System.Collections;

public class Animal_move : MonoBehaviour {

    public bool test;
    public bool wagging = false;
    public Animator anim;
    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(wagnomore());
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (test)
        {
            wagging = true;
            anim.SetBool("Wagging", wagging);
        }
        else
        {
            wagging = false;
            anim.SetBool("Wagging", wagging);
        }
	}
    IEnumerator wagnomore()
    {
        test = true;
        yield return new WaitForSeconds(3);
        test = false;
    }
}
