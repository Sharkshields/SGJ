using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAutomat : MonoBehaviour
{
    
    [SerializeField] private string _pathcToScene;
    private InteractionWithObject _interactObject;
    private LevelComponent levelComponent;
    private Scene _scene;

    private void Awake()
    {
        levelComponent = FindObjectOfType<LevelComponent>();
        _interactObject = GetComponent<InteractionWithObject>();
        _interactObject.OnInteract += OnInteract;
    }

    private void OnInteract(Hero obj)
    {
        //_scene = 
        // SceneManager.SetActiveScene();
        var a = SceneManager.GetActiveScene();
        SceneManager.LoadScene(_pathcToScene,LoadSceneMode.Additive);
        levelComponent.gameObject.SetActive(false);
        Debug.Log(a.name);
        SceneManager.UnloadScene(a);
        //AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_scene);

    }
}
