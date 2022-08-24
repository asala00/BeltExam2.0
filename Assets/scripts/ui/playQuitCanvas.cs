using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayQuitCanvas : MonoBehaviour
{

    public void PlayG()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitG()
    {
        Application.Quit();
    }
    
}
