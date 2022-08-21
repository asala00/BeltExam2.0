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
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("win"))
        {
            PlayerHUD.SetActive(false);
            winCanvas.SetActive(true);
        }

        if (other.gameObject.CompareTag("powerUp") || other.gameObject.CompareTag("SpecialPowerUp"))
        {
            playerMovemntScript.jumpHeight ++;
            playerMovemntScript.Playerspeed++;
            Pcount++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("SpecialPowerUp"))
        {
            playerMovemntScript.jumpHeight += 5;
            playerMovemntScript.Playerspeed++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("hazard"))
        {
            SceneManager.LoadScene(0);
        }

        if (other.gameObject.CompareTag("camChange"))
        {
            endGoalHintCam.SetActive(true);
            Invoke("disableEndGoalHint",4);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Respawn"))
        {
            SceneManager.LoadScene(0);
        }

        if (other.CompareTag("gunBox"))
        {
            getGun.SetActive(true);
            Destroy(other.gameObject);
        }
    }

    void disableEndGoalHint()
    {
        endGoalHintCam.SetActive(false);
    }
}
