using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public AudioSource AudioSource; //the Audio Source component itself so we can control it thro script
    
    void Start()
    {
        // Using the Start method to directly grab the Audio Source component from the game object itself and plug it in as our variable.
        AudioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        MusicBoxControls();
    }

    void MusicBoxControls() //will code the audio to start acoording to input instead of on awake
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AudioSource.Stop();
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AudioSource.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AudioSource.Pause();
        }

    }
}
