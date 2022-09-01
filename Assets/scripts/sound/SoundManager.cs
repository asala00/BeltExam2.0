using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip shoot;
    public AudioClip powerUp;
    public AudioClip defeatTurret;
    public AudioClip rickRoll;
    public AudioClip respawn;
    public AudioClip win;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ShootSFX()
    {
        audioSource.PlayOneShot(shoot);
    }

    public void PowerUpSFX()
    {
        audioSource.PlayOneShot(powerUp);
    }

    public void DefeatTurretSFX()
    {
        audioSource.PlayOneShot(defeatTurret);
    }

    public void RickRollSFX()
    {
        audioSource.PlayOneShot(rickRoll);
    }

    public void RespawnSFX()
    {
        audioSource.PlayOneShot(respawn);
    }

    public void WinSFX()
    {
        audioSource.PlayOneShot(win);
    }
}
