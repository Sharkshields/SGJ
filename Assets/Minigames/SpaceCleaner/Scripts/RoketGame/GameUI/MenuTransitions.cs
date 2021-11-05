using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTransitions : MonoBehaviour
{
    public void onClickExit()
    {
        SceneManager.LoadScene(0);
    }
    public void onClickRestart()
    {
        SceneManager.LoadScene(1);
    }
}
