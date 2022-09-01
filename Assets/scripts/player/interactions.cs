using UnityEngine;
using UnityEngine.UI;     //to code the text & images ui
using TMPro;

public class Interactions : MonoBehaviour
{
    #region Serialized Fields
    
    [SerializeField] private CharacterController playersController;
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private GameObject playerHUD;
    [SerializeField] private GameObject endGoalHintCam;
    [SerializeField] private TextMeshProUGUI pScore;  //Text variables grant us access to those objects' Text components

    //health bar vars
    [SerializeField] private Image hpBar;
    [SerializeField] private GameObject getGun;
    
    //sound FX
    [SerializeField] private SoundManager sm;
    
    //respawns
    [SerializeField] private Transform respawnCheckPointR;
    [SerializeField] private Transform respawnCheckPointL;
    [SerializeField] private Transform respawnCheckPointOffLevel;
    
    #endregion
    
    public MoveIn3d playerMovemntScript;
    private int _pCount;
    public float hp = 1.0f;

    private void Start()
    {
        pScore.text = ("0");
        getGun.SetActive(false);
    }

    private void Update()
    {
        pScore.text = ("18/" + _pCount);
        hpBar.fillAmount = hp;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("enemy"))
        {
            hp -= 0.1f;
        }
        if (hit.gameObject.CompareTag("enemy") && hp < 0.2f)
        {
            transform.position = respawnCheckPointR.position;
            hp = 1.0f;
            sm.RespawnSFX();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("win"))
        {
            playerHUD.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            winCanvas.SetActive(true);
            sm.WinSFX();
        }

        if (other.gameObject.CompareTag("powerUp"))
        {
            playerMovemntScript.jumpHeight ++;
            playerMovemntScript.playerSpeed++;
            _pCount++;
            sm.PowerUpSFX();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("SpecialPowerUp"))
        {
            playerMovemntScript.jumpHeight += 5;
            playerMovemntScript.playerSpeed++;
            _pCount++;
            sm.PowerUpSFX();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("camChange"))
        {
            endGoalHintCam.SetActive(true);
            playerMovemntScript.enabled = false;
            Invoke("DisableEndGoalHint",4);
            Destroy(other.gameObject);
        }
        
        if (other.CompareTag("gunBox"))
        {
            getGun.SetActive(true);
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.CompareTag("offLevel"))
        {
            playersController.enabled = false;
            Debug.Log("fell off");
            transform.position = respawnCheckPointOffLevel.position;
            playersController.enabled = true;
            sm.RespawnSFX();
        }
        
        if (other.gameObject.CompareTag("hazard"))
        {
            playersController.enabled = false;
            transform.position = respawnCheckPointL.position;
            playersController.enabled = true;
            sm.RespawnSFX();
        }
    }

    void DisableEndGoalHint()
    {
        endGoalHintCam.SetActive(false);
        playerMovemntScript.enabled = true;
    }
}
