using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ScoreManager: MonoBehaviour
{
    [SerializeField] private SpawnRocket spawnRocket;
    [SerializeField] private Save save;
    private Rocket player;
    private int score;

    public event Action<int> updateUI;
    public event Action<int> startRecordUI;
    public event Action<int, int> endGame;

    private void Awake()
    {
        spawnRocket.OnGetRocket += SetPlayer;
    }

    private void Start()
    {
        startRecordUI(save.RecordScore);
    }
    private void SetPlayer(Rocket _player)
    {
        player = _player;
        player.OnGrabGarbage += OnGrabGarbage;
        player.OnDie += EndGame;
    }

    private void OnGrabGarbage(int _score)
    {
        score += _score;
        updateUI(score);
    }
     private void EndGame()
    {
        if (score> save.RecordScore)
        {
            save.RecordScore = score;
        }
        endGame(score, save.RecordScore);
        save.Score += score;
        save.SaveState();
    }
}
