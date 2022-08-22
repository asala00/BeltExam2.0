using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;     //to code the text & images ui
using TMPro;
using UnityEngine.SceneManagement;

public class interactions : MonoBehaviour
{
    [SerializeField]private GameObject winCanvas;
    [SerializeField] private GameObject PlayerHUD;
    public move3d playerMovemntScript;
    [SerializeField] private GameObject endGoalHintCam;
    [SerializeField] private TextMeshProUGUI Pscore;     //Text variables grant us access to those objects' Text components
    private int Pcount;
    public float HP = 1.0f;
    //healthbar vars
    [SerializeField] private Image HPBar;
    [SerializeField] private GameObject getGun;
    //sound FX
    [SerializeField] private SoundManager sm;
    //respawn
    [SerializeField] private Transform respawnCheckPointR;
    [SerializeField] private Transform respawnCheckPointL;
    [SerializeField] private Transform respawnCheckPointOffLevel;


    private void Start()
    {
        Pscore.text = ("0");
        getGun.SetActive(false);
    }

    private void Update()
    {
        Pscore.text = ("18/" + Pcount);
        HPBar.fillAmount = HP;

        if (HP < 0.0f)
        {
            transform.position = respawnCheckPointR.position;
            HP = 1.0f;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("win"))
        {
            PlayerHUD.SetActive(false);
            winCanvas.SetActive(true);
        }

        if (other.gameObject.CompareTag("powerUp"))
        {
            playerMovemntScript.jumpHeight ++;
            playerMovemntScript.Playerspeed++;
            Pcount++;
            sm.powerUpSFX();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("SpecialPowerUp"))
        {
            playerMovemntScript.jumpHeight += 5;
            playerMovemntScript.Playerspeed++;
            Pcount++;
            sm.powerUpSFX();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("hazard"))
        {
            transform.position = respawnCheckPointL.position;
        }

        if (other.gameObject.CompareTag("camChange"))
        {
            endGoalHintCam.SetActive(true);
            Invoke("DisableEndGoalHint",4);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("offLevel"))
        {
            Debug.Log("fell off");
            transform.position = respawnCheckPointOffLevel.position;
        }

        if (other.CompareTag("gunBox"))
        {
            getGun.SetActive(true);
            Destroy(other.gameObject);
        }
        
    }

    void DisableEndGoalHint()
    {
        endGoalHintCam.SetActive(false);
    }
}
