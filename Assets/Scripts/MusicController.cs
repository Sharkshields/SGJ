using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OSSC;

public class MusicController : MonoBehaviour
{
    public SoundController SoundController;
    ISoundCue music;
    [SerializeField] public string SoundItemName = "Main Menu";

    //bool m_Play;

    public void StartNewMusic(string musicToStart, float fadeInTime, float fadeOutTime, bool isLooped)
    {
        Debug.Log("Принял");
        //        m_MyAudioSource.Play;
        if (music != null)
            SoundController.StopAll();
        PlaySoundSettings settings = new PlaySoundSettings();
        settings.Init();

        settings.name = musicToStart;
        settings.isLooped = isLooped;
        settings.fadeInTime = fadeInTime;
        settings.fadeOutTime = fadeOutTime;
        music = SoundController.Play(settings);
    }

}
