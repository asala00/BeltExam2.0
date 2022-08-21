using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip shoot, powerUp, defeatTurret;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ShootSFX()
    {
        audioSource.PlayOneShot(shoot);
    }

    public void powerUpSFX()
    {
        audioSource.PlayOneShot(powerUp);
    }

    public void defeatTurretSFX()
    {
        audioSource.PlayOneShot(defeatTurret);
    }
}
