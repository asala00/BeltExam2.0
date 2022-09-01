using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public MoveIn3d PlayerMovemntScript;
    [SerializeField] private GameObject titleScreenCanvas;
    [SerializeField] private GameObject playerHUD;
    [SerializeField] private GameObject refundCanvas;
    public SoundManager SM;
    public AudioSource BackGroundMusic;

    private void Awake()
    {
        PlayerMovemntScript.enabled = false;
    }

    public void StartG()
    {
        PlayerMovemntScript.enabled = true;
        titleScreenCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        playerHUD.SetActive(true);
    }
    public void Refund()
    {
        BackGroundMusic.enabled = false;
        refundCanvas.SetActive(true);
        SM.RickRollSFX();
    }

}
