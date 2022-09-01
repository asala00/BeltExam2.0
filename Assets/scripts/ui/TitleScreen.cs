using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private GameObject cameraMovement;
    [SerializeField] private GameObject titleScreenCanvas;
    [SerializeField] private GameObject playerHUD;
    [SerializeField] private GameObject refundCanvas;
    public SoundManager sm;
    public AudioSource backGroundMusic;
    public MoveIn3d playerMovemntScript;

    private void Start()
    {
        cameraMovement.SetActive(false);
    }

    public void StartG()
    {
        cameraMovement.SetActive(true);
        playerMovemntScript.enabled = true;
        titleScreenCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        playerHUD.SetActive(true);
    }
    public void Refund()
    {
        backGroundMusic.enabled = false;
        refundCanvas.SetActive(true);
        sm.RickRollSFX();
    }

}
