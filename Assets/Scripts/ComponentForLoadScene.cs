using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComponentForLoadScene : MonoBehaviour
{
    Scene scene;

    private void Awake()
    {
        scene = SceneManager.GetActiveScene();

        //SceneManager.CreateScene()
    }
}
