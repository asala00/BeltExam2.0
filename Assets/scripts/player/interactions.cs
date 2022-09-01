using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;     //to code the text & images ui
using TMPro;
using UnityEngine.SceneManagement;

public class Interactions : MonoBehaviour
{
    [SerializeField] private CharacterController playersController;
    [SerializeField] private GameObject _winCanvas;
    [SerializeField] private GameObject _playerHUD;
    public MoveIn3d PlayerMovemntScript;
    [SerializeField] private GameObject _endGoalHintCam;
    [SerializeField] private TextMeshProUGUI _pScore;     //Text variables grant us access to those objects' Text components
    private int _pCount;
    public float HP = 1.0f;
    //healthbar vars
    [SerializeField] private Image _hpBar;
    [SerializeField] private GameObject _getGun;
    //sound FX
    [SerializeField] private SoundManager _sm;
    //respawn
    [SerializeField] private Transform _respawnCheckPointR;
    [SerializeField] private Transform _respawnCheckPointL;
    [SerializeField] private Transform _respawnCheckPointOffLevel;


    private void Start()
    {
        _pScore.text = ("0");
        _getGun.SetActive(false);
    }

    private void Update()
    {
        _pScore.text = ("18/" + _pCount);
        _hpBar.fillAmount = HP;
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("enemy"))
        {
            HP -= 0.1f;
        }
        if (hit.gameObject.CompareTag("enemy") && HP < 0.2f)
        {
            transform.position = _respawnCheckPointR.position;
            HP = 1.0f;
            _sm.RespawnSFX();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("win"))
        {
            _playerHUD.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            _winCanvas.SetActive(true);
            _sm.WinSFX();
        }

        if (other.gameObject.CompareTag("powerUp"))
        {
            PlayerMovemntScript.JumpHeight ++;
            PlayerMovemntScript.PlayerSpeed++;
            _pCount++;
            _sm.PowerUpSFX();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("SpecialPowerUp"))
        {
            PlayerMovemntScript.JumpHeight += 5;
            PlayerMovemntScript.PlayerSpeed++;
            _pCount++;
            _sm.PowerUpSFX();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("camChange"))
        {
            _endGoalHintCam.SetActive(true);
            PlayerMovemntScript.enabled = false;
            Invoke("DisableEndGoalHint",4);
            Destroy(other.gameObject);
        }
        

        if (other.CompareTag("gunBox"))
        {
            _getGun.SetActive(true);
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.CompareTag("offLevel"))
        {
            playersController.enabled = false;
            Debug.Log("fell off");
            transform.position = _respawnCheckPointOffLevel.position;
            playersController.enabled = true;
            _sm.RespawnSFX();
        }
        
        if (other.gameObject.CompareTag("hazard"))
        {
            playersController.enabled = false;
            transform.position = _respawnCheckPointL.position;
            playersController.enabled = true;
            _sm.RespawnSFX();
        }
    }

    void DisableEndGoalHint()
    {
        _endGoalHintCam.SetActive(false);
        PlayerMovemntScript.enabled = true;
    }
}
