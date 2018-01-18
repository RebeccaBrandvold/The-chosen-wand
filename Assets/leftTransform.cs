using UnityEngine;
using System.Collections;

public class leftTransform : MonoBehaviour {
    public GameObject Exit;
    public GameObject Player;
    public GameObject Entry2;
    public Transform animal;
    private float diff;
    private float diff2;
    public bool okayToTeleport = false;

    
	 
	void Update () {
       diff = Player.transform.position.x - this.transform.position.x;
       diff2 = Entry2.transform.position.x - this.transform.position.x;//space between this and entry2
       
        Debug.Log("left"+ diff);

        if(diff >=0)
        {
            okayToTeleport = true;
          //  animal.gameObject.SetActive(true);
        }
        else
        {
            okayToTeleport = false;
           // animal.gameObject.SetActive(false);
        }
       // animal.gameObject.SetActive(true);

	}

    private Vector2 teleport()
    {
        return animal.position = Exit.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (okayToTeleport && col.gameObject.CompareTag("Animal"))
        {
            teleport();
        }
    }
}
