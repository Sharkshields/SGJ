using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject charCanvas;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    private void Start()
    {
        mainCanvas.SetActive(true);
    }

    public void onClickStart()
    {
        SceneManager.LoadScene("SpaceCleanerGame");
    }

    public void onClickExit()
    {
        SceneManager.LoadScene("SpaceCleanerMainMenu");
    }

    public void GoToHome()
    {
        //SceneManager.
    }
   

    public void onClickChar()
    {
        mainCanvas.SetActive(false);
        charCanvas.SetActive(true);
    }

    public void onClickMenu()
    {
        charCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }
}
