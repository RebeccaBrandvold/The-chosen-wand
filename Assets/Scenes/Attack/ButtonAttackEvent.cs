using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonAttackEvent : MonoBehaviour {
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;

    public float timeCount = 3f;
    private bool AnimalKilled = false;
    private bool AnimalAttacks = false;
  
    

  
	void Start () {
        //  button1.SetActive(false);//to make buttons dissapear and reappear FALSE REMOVES BUTTON
        //  button2.SetActive(true);//to make buttons dissapear and reappear TRUE SHOWS BUTTON

        /*button1 = GetComponent<Button>();
        button1.onClick.AddListener(()=> HideButton());*/
        //button1 = GameObject.Find("Hit");
    }

    public void Button1Press()
    {
        // button1 = GetComponent<Button>();
        button1.SetActive(false);
    }
    public void Button2Press()
    {
        button2.SetActive(false);
    }
    public void Button3Press()
    {
        button3.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
       // button1.SetActive(true);//to make buttons dissapear and reappear
       // button2.SetActive(false);//to make buttons dissapear and reappear 
    }
 

}
/*public GameObject button1;
public GameObject button2;
public GameObject button3;
private bool AnimalKilled = false;
private bool AnimalAttacks = false;*/

/*What I want :
    1 : Gjøre sånn at knappene popper opp på skjermen. V
    2 : Gjøre sånn at knappene forsvinner når man har trykket på dem.
    3 : Gjøre sånn at hvis knappene har blitt trykket på i en spesiel rekke følge dreper man dyret.           
    4 : Gjøre sånn at hvis knappene som ikke er riktig rekkefølge tar bort en av 3 sjanser.
    5 : Kanskje legge til tid på de
    6 : Gjøre sånn at man dør når 'livene' er brukt opp
    */