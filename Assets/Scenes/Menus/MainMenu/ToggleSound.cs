using UnityEngine;
using System.Collections;

public class ToggleSound : MonoBehaviour {

    AudioSource audioSource;
    bool soundToggle = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Example()
    {
        if (soundToggle)
        {
           //audioListener.volume = 0.5F;
            audioSource.mute = !audioSource.mute;//mutes all sound
        }
       // else
        //{
            //AudioListener.volume = 1.0f; //idk what im doing im trying to make a thing to turn off all sound 
    //    }
    }
    
    /*
     OnGUI()
        {
            soundToggle = !soundToggle;
            if (soundToggle)
            {
                //audioSource.SetActive(true);
                audioSource.mute = true;
                //audioSource.volume = 1.0f;
            }
            else
            {
                //audioSource.SetActive(false);
                audioSource.mute = false;
                //audioSource.volume = 0.0f;
            }
        }*/
}
