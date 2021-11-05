using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionTextToLevel_1 : MonoBehaviour
{
      
    public void Start()
    {
        
        StartCoroutine(CoroutineNextLevel());
        
    }
    
    IEnumerator CoroutineNextLevel()
    {
        yield return new WaitForSeconds(14.1f);
        AsyncOperation loading = SceneManager.LoadSceneAsync(0); // 0 - ������ ����� �� BuildSettings, ������� ������ �����������

        while (!loading.isDone)
        {
            yield return null;
        }
        
    } 
}
