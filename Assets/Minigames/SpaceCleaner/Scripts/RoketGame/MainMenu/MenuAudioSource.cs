using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioSource : MonoBehaviour
{
    private AudioSource _audio;
    [SerializeField] private AudioClip tabStartButtom;
    [SerializeField] private AudioClip tabMainMenuButtom;
    [SerializeField] private AudioClip tabShopButtom;

    private void Awake()
    {
        _audio = this.GetComponent<AudioSource>();
    }
    public void OnTabStart()
    {
        _audio.PlayOneShot(tabStartButtom);
    }

    public void OnTabMainMenu()
    {
        _audio.PlayOneShot(tabMainMenuButtom);
    }

    public void OnTabShop()
    {
        _audio.PlayOneShot(tabShopButtom);
    }
}
