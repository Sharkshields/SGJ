using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RoketUI : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private RocketInfoUI info;
    [SerializeField] private GameObject buttonUse;
    [SerializeField] private Text text;
    [SerializeField] private Image image;
    //[SerializeField] private Button buttonUse;
    public event Func<int,bool> updateScore;
    public event Action<Rocket, Sprite> updateRocket;

    private void Awake()
    {
        image = this.GetComponent<Image>();
        buttonUse.gameObject.SetActive(false);
    }

    public void Constructor(RocketInfoUI _info)
    {
        info = _info;
        image.sprite = info.Image;
        image.preserveAspect = true;
        if (!info.OnSold)
        {
            buttonUse.gameObject.SetActive(true);
            text.text = "Цена: " + info.Price;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!info.OnSold)
        {
            if (updateScore(info.Price))
            {
                buttonUse.gameObject.SetActive(false);
                info.OnSold=true;
                info.SaveState();
            }
        }
        else
        {
            updateRocket(info.Roket, info.Image);
        }

    }
}
