using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    [SerializeField] private string soundControllerObgectName;
    [SerializeField] private string musicToStart;
    [SerializeField] private bool isDestroyable;
    [SerializeField] private float fadeInTime;
    [SerializeField] private float fadeOutTime;
    [SerializeField] private bool isLooped;
    GameObject Control;

    public void Awake()
    {
        soundControllerObgectName = "Sound Control and Triggers";
        Control = GameObject.Find(soundControllerObgectName);
        isDestroyable = true;
        fadeInTime = 1f;
        fadeOutTime = 2f;
        isLooped = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Передал");
        Control.GetComponent<MusicController>().StartNewMusic(musicToStart, fadeInTime, fadeOutTime, isLooped);
        if (isDestroyable)
            Destroy(this);
    }

}

