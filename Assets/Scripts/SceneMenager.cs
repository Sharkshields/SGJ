using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneMenager : MonoBehaviour
{
    [SerializeField] private string sceneName;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "Main Menu")
        {
            LoadScene("Main Menu");
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton10) && SceneManager.GetActiveScene().name != "Main Menu")
        {
            LoadScene("Main Menu");
        }
    }
    public void Exit()
    {
        Application.Quit();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        LoadScene(sceneName);
    }

}
