using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playQuitCanvas : MonoBehaviour
{

    public void playG()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitG()
    {
        Application.Quit();
    }
    
}
