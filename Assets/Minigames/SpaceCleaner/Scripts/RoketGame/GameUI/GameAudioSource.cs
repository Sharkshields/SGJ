using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioSource : MonoBehaviour
{
    [SerializeField] private AudioClip tabRestartButtom;
    [SerializeField] private AudioClip tabMainMenuButtom;
    [SerializeField] private AudioClip grabGarbage;
    [SerializeField] private AudioClip death;
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
        _player.OnGrabGarbage += OnGrabGarbage;
        _player.OnDie += OnDeth;
    }
    private void OnDisable()
    {
        _player.OnGrabGarbage -= OnGrabGarbage;
        spawnRocket.OnGetRocket -= SetPlayer;
        _player.OnDie -= OnDeth;
    }


    public void OnTabRestart()
    {
        _audio.PlayOneShot(tabRestartButtom);
    }

    public void OnTabMainMenu()
    {
        _audio.PlayOneShot(tabMainMenuButtom);
    }

    private void OnGrabGarbage(int score)
    {
        _audio.PlayOneShot(grabGarbage);
    }

    private void OnDeth()
    {
        _audio.PlayOneShot(death);
    }
   
}
