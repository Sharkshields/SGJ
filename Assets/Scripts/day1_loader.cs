using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class day1_loader : MonoBehaviour
{
    public void Start()
    {

        StartCoroutine(CoroutineNextLevel());

    }

    IEnumerator CoroutineNextLevel()
    {
        yield return new WaitForSeconds(4.5f);
        AsyncOperation loading = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1); // следующий индекс сцены из BuildSettings, которая должна запускаться

        while (!loading.isDone)
        {
            yield return null;
        }

    }
}
