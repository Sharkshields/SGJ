using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAutomat : MonoBehaviour
{
    [SerializeField] private string _scene;
    private InteractionWithObject _interactObject;

    private void Awake()
    {
        _interactObject = GetComponent<InteractionWithObject>();
        _interactObject.OnInteract += OnInteract;
    }

    private void OnInteract(Hero obj)
    {
        // SceneManager.SetActiveScene();
        //SceneManager.LoadSceneAsync(_scene,LoadSceneMode.Additive);
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName(_scene));
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_scene);

    }
}
