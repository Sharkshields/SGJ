using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionTextToLevel_1 : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    public void Start()
    {
        
        StartCoroutine(CoroutineNextLevel());
        
    }
    
    IEnumerator CoroutineNextLevel()
    {
        yield return new WaitForSeconds(14.1f);
        AsyncOperation loading = SceneManager.LoadSceneAsync(sceneIndex); // 0 - индекс сцены из BuildSettings, которая должна запускаться

        while (!loading.isDone)
        {
            yield return null;
        }
        
    } 
}
