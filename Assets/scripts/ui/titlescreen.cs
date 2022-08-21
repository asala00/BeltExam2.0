using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titlescreen : MonoBehaviour
{
    [SerializeField] private GameObject titleScreenCanvas;
    [SerializeField] private GameObject playerHUD;
    public void startG()
    {
        titleScreenCanvas.SetActive(false);
        playerHUD.SetActive(true);
    }
    public void QuitG()
    {
        Application.Quit();
    }
    
}
