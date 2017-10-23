using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WordManagment : MonoBehaviour {

	public Text sentence;
	//public Text curword;
	public Text result;
	//public GameObject triggerSwim;
	public Player_movement plmo;
	//public string test;

	//private bool newWord = false;

	void Start () {
		//sentence = GetComponent<Text> ();
		//curword = GetComponent<Text> ();
	}

	void Update () {
		//works but if the word is supposed to be able to pick it up, then it should be GameObject due to the colliderbox we need for that
		if (plmo.hitWord == true) 
		{
			if (plmo.hasWord && !plmo.FirstWord) {
				Debug.Log ("Replacing words");
				Debug.Log (sentence.text.Length);
				//int index = sentence.text.LastIndexOf (" ");
				//sentence.text = sentence.text.Remove (index);
				//plmo.stored.text = plmo.stored.text.Remove(5, (plmo.stored.text.Length - plmo.oldWord.text.Length));
				sentence.text = sentence.text.Remove (4, (sentence.text.Length - plmo.oldWord.text.Length));
				//sentence.text.Replace (plmo.curword.text, plmo.newWord.text);
			}
			result.text = sentence.text + plmo.newWord.text;
			sentence.text = result.text;
			plmo.hitWord = false;
		}
	}
}
