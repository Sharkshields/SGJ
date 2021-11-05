using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] private Text curentScore;
    [SerializeField] private Text recordScore;
    [SerializeField] private ScoreManager manager;
    private void Awake()
    {
        manager.endGame += EndGame;
        this.gameObject.SetActive(false);
    }

    private void EndGame(int _curentScore, int _recordScore)
    {
        this.gameObject.SetActive(true);
        curentScore.text = _curentScore.ToString();
        recordScore.text = _recordScore.ToString();

    }

}
