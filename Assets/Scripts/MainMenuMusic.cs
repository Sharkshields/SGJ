using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OSSC;
using UnityEngine.Audio;

public class MainMenuMusic : MonoBehaviour
{
    public SoundController SoundController;
    public AudioMixer audioMixer;
//    [SerializeField] public float volume;
    [SerializeField] private string musicToStart;
    [SerializeField] private float fadeInTime;
    [SerializeField] private float fadeOutTime;
    [SerializeField] private bool isLooped;
    ISoundCue music;

    // Start is called before the first frame update
    void Start()
    {
        PlaySoundSettings settings = new PlaySoundSettings();
        settings.Init();

        settings.name = musicToStart;
        
        settings.isLooped = isLooped;
        settings.fadeInTime = fadeInTime;
        settings.fadeOutTime = fadeOutTime;
        music = SoundController.Play(settings);

        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
public void StopMusic()
    {
        SoundController.StopAll();
    }


    public void DestroyMusic()
    {
        Destroy(this.gameObject);
    }


}
