using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTriggerLoadLevel : MonoBehaviour
{
    public GameObject guiObject;
    public string levelToLoad;

    void Start()
    {
        guiObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            guiObject.SetActive(true);
          
        }
    }

    private void Update()
    {
        if (guiObject.activeInHierarchy == true && Input.GetButtonDown("Use"))
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        guiObject.SetActive(false);
    }
    
}
