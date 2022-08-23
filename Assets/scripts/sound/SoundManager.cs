using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip Shoot, PowerUp, DefeatTurret, RickRoll;
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void ShootSFX()
    {
        AudioSource.PlayOneShot(Shoot);
    }

    public void PowerUpSFX()
    {
        AudioSource.PlayOneShot(PowerUp);
    }

    public void DefeatTurretSFX()
    {
        AudioSource.PlayOneShot(DefeatTurret);
    }

    public void RickRollSFX()
    {
        AudioSource.PlayOneShot(RickRoll);
    }
}
