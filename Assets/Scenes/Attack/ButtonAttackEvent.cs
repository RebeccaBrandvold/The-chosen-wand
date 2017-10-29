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
        
    }

    public void Button1Press()
    {
        // button1 = GetComponent<Button>();
        button1.SetActive(false);//True makes thewords reappear.
    }
    public void Button2Press()
    {
        button2.SetActive(false);
    }
    public void Button3Press()
    {
        button3.SetActive(false);
    }
    
    void Update () {}
 /* //Yes hello i obvisouly know how to code IM TRYING TO MAKE THE RIGHT KILLING SEQUENCE???
    // HYEALP AND EVERY other pattern or button is wrong to press?????
    public void ButtonSequence()
    {
        if(Button1Press && Button2Press && Button3Press) //this is obisouly only if there's more words to press. 
        {//would be nice if there was a right sequence instead.... 
            Animalkilled = true;
        }//If the animal isn't killed the player will lose 1 health and get attacked. unless game over ofc
    }*/
}
/*public GameObject button1;
public GameObject button2;
public GameObject button3;
private bool AnimalKilled = false;
private bool AnimalAttacks = false;*/

/*What I want :
    1 : Gjøre sånn at knappene popper opp på skjermen. X
    2 : Gjøre sånn at knappene forsvinner når man har trykket på dem. X
    3 : Gjøre sånn at hvis knappene har blitt trykket på i en spesiel rekke følge dreper man dyret.           
    4 : Gjøre sånn at hvis knappene som ikke er riktig rekkefølge tar bort en av 3 sjanser.
    5 : Kanskje legge til tid på de
    6 : Gjøre sånn at man dør når 'livene' er brukt opp
    */