using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public AudioSource audioSource; //the Audio Source component itself so we can control it thro script
    
    void Start()
    {
        // Using the Start method to directly grab the Audio Source component from the game object itself and plug it in as our variable.
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        MusicBoxControls();
    }

    void MusicBoxControls() //will code the audio to start according to input instead of on awake
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            audioSource.Stop();
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            audioSource.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            audioSource.Pause();
        }

    }
}
