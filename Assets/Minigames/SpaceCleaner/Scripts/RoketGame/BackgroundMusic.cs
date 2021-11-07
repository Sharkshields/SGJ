using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private SpawnRocket spawnRocket;
    private AudioSource _audio;
    private Rocket _player = new Rocket();
    private void Awake()
    {
        _audio = this.GetComponent<AudioSource>();
        spawnRocket.OnGetRocket += SetPlayer;
    }


    private void SetPlayer(Rocket player)
    {
        _player = player;
        _player.OnDie += OnDeth;
    }

    private void OnDeth()
    {
        Destroy(gameObject);
    }
}
