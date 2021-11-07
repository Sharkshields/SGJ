using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScore : MonoBehaviour
{
    [SerializeField] private MainMenuManager manager;
    private Text text;
    private void Awake()
    {
        text = this.GetComponent<Text>();
        manager.updateScore += UpdateScore;
    }
    public void UpdateScore(int score)
    {
        text.text = score.ToString();
    }

}
