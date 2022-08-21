using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundControl : MonoBehaviour
{
    private AudioSource _audioSource; //the Audio Source component itself so we can control it thro script
    
    void Start()
    {
        // Using the Start method to directly grab the Audio Source component from the game object itself and plug it in as our variable.
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MusicBoxControls();
    }

    void MusicBoxControls() //will code the audio to start acoording to input instead of on awake
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _audioSource.Stop();
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _audioSource.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _audioSource.Pause();
        }

    }
}
