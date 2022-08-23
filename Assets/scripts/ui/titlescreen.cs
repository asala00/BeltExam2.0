using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titlescreen : MonoBehaviour
{
    [SerializeField] private GameObject titleScreenCanvas;
    [SerializeField] private GameObject playerHUD;
    [SerializeField] private GameObject _refundCanvas;
    public SoundManager SM;
    public void startG()
    {
        titleScreenCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        playerHUD.SetActive(true);
    }
    public void Refund()
    {
        _refundCanvas.SetActive(true);
        SM.RickRollSFX();
    }

}
